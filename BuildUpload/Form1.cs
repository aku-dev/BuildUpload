using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.IO.MemoryMappedFiles;
using NashAPIv1;
using System.Security.Cryptography;

namespace BuildUpload
{
    public partial class Form1 : Form
    {
        private int _gameID = 0;
        private string _tmpPath = @"C:\temp\";
        private const int _CHUNK_SIZE = 1024*1024*32;
        private byte[] _csm = null;
        private MainClass _api = new MainClass();

        public Form1()
        {
            InitializeComponent();            
        }

        public void BusyStatus(bool on)
        {
            timer1.Enabled = on;
            if(on == true)
            {
                progressBar1.Value = 10;
            }
            if(on == false)
            {
                progressBar1.Value = 0;
                buttonMakePackage.Enabled = true;
                buttonUpload.Enabled = true;
            }
        }

        public void Log(string str)
        {            
            Console.WriteLine(str);
            textBoxLogs.Text += $"[{DateTime.Now}] {str}\r\n";

            textBoxLogs.SelectionStart = textBoxLogs.TextLength;
            textBoxLogs.ScrollToCaret();
        }

        public async void CompressAsync(string sourceDir, string compressedFile)        
        {
            bool success = false;

            BusyStatus(true);
            await Task.Run(() =>
            {
                try
                {
                    if (File.Exists(compressedFile)) File.Delete(compressedFile);
                    ZipFile.CreateFromDirectory(sourceDir, compressedFile, CompressionLevel.Optimal, false);
                }
                finally { success = true; }
                return success;
            });
            BusyStatus(false);

            if (success && File.Exists(compressedFile))
            {
                Log($"Done.");

                CreateChunksAsync(compressedFile);
            } else {
                Log($"Error: compress fail!");
            }
            
        }

        public async void CreateChunksAsync(string compressedFile)
        {
            bool success = false;            

            Log($"Create chunks...");

            BusyStatus(true);
            await Task.Run(() =>
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(compressedFile);      
                    long c_chunks = fileInfo.Length / _CHUNK_SIZE;
                    long last_length = fileInfo.Length - _CHUNK_SIZE * c_chunks;

                    using (var mmf = MemoryMappedFile.CreateFromFile(compressedFile, FileMode.Open, "packHandle", fileInfo.Length))
                        for (int i = 0; i <= c_chunks; i++)
                        {
                            long offset = _CHUNK_SIZE * i;
                            long length = (i != c_chunks) ? _CHUNK_SIZE : last_length;

                            using (var accessor = mmf.CreateViewAccessor(offset, length))
                            {
                                string chunk_file = "chunk_" + _gameID + "_" + i + ".tmp";
                                var readOut = new byte[length];
                                accessor.ReadArray(0, readOut, 0, readOut.Length);

                                using (BinaryWriter BW = new BinaryWriter(File.Open(_tmpPath + chunk_file, FileMode.Create)))
                                {
                                    int j = 0;
                                    while (j < readOut.Length)
                                    {
                                        BW.Write(readOut[j]);
                                        //byte w = (byte)(readOut[j] ^ (_CRT_KEY + _gameID));
                                        //BW.Write(w);
                                        j++;
                                    }
                                }
                            }                    
                        }
                }
                finally { success = true; }
                return success;
            });
            BusyStatus(false);            

            if (success)
            {
                Log($"Done.");
            } else {
                Log($"Error: Fail create chunks.");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = textBoxPassword.PasswordChar == '\0' ? '*' : '\0';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxLogs.Text = "";
            _tmpPath = Path.GetTempPath();

            textBoxUrl.Text = MainClass.ConfigDownlowdUrl;

            if (checkBoxSavePassword.Checked)
            {
                textBoxLogin.Text = Properties.Settings.Default.form_login;
                textBoxPassword.Text = Properties.Settings.Default.form_password;
            }

            textBoxGameID.Text = Properties.Settings.Default.from_game_id;
            textBoxBuildFolder.Text = Properties.Settings.Default.form_folder;
            textBoxDescription.Text = Properties.Settings.Default.from_description;
            checkBoxReleased.Checked = Properties.Settings.Default.form_released;
        }

        /// <summary>
        /// Browse
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Диалог поиска файла
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = textBoxBuildFolder.Text;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBoxBuildFolder.Text = fbd.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Make
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            buttonMakePackage.Enabled = false;
            int.TryParse(textBoxGameID.Text, out _gameID);
            if(_gameID != 0)
            {
                if(textBoxBuildFolder.Text != "" && Directory.Exists(textBoxBuildFolder.Text))
                {
                    string zip = _tmpPath + "send_pack_" + _gameID + ".zip";

                    Log("Start pack...");                    
                    Log($"Packing. Output file: {zip}");

                    CompressAsync(textBoxBuildFolder.Text, zip);
                } else {
                    Log("Error: Select build folder.");
                    buttonMakePackage.Enabled = true;
                }
            } else {
                Log("Error: Game ID is 0.");
                buttonMakePackage.Enabled = true;
            }            
        }

        /// <summary>
        /// Upload
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            buttonUpload.Enabled = false;
            int.TryParse(textBoxGameID.Text, out _gameID);
            if (_gameID == 0)
            {
                buttonUpload.Enabled = true;
                Log("Error Game ID");
                return;
            }

            // Проверяем что пакеты есть и созданы
            string zip = _tmpPath + "send_pack_" + _gameID + ".zip";
            if(!File.Exists(zip))
            {
                buttonUpload.Enabled = true;
                Log("Upload stop: To get started, click [Make Package].");
                return;
            }
            long pakLength = new FileInfo(zip).Length;
            string[] pakChunks = Directory.GetFiles(_tmpPath, "chunk_"+ _gameID + "_*.tmp", SearchOption.TopDirectoryOnly);
            if(pakChunks.Length <= 0)
            {
                buttonUpload.Enabled = true;
                Log("Upload stop: No packets to send.");
                return;
            }

            // Вычисляем контрольную сумму.
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(zip))
                {
                    _csm = md5.ComputeHash(stream);
                }
            }

            // Загружаем файлы на сервак
            Log("Get Session Token.");
            if (_api.InitToken())
            {
                Log("Get RSA Public Key.");
                _api.GetRSA();

                Log("User login...");
                if (_api.UserLogin(textBoxLogin.Text, textBoxPassword.Text))
                {
                    Log("Create game store.");
                    // Отправить данные для создания билда
                    string pack_id = _api.UserCreateBuildStore(_gameID, checkBoxReleased.Checked, textBoxDescription.Text, _csm, pakLength, pakChunks.Length);
                    if (pack_id != null && pack_id != "")
                    {
                        Log("Pack ID:" + pack_id);
                        SendFiles(pack_id);                        
                    }
                    else
                    {
                        buttonUpload.Enabled = true;
                        Log("Error Game ID:");
                        Log(MainClass.ErrorMessage);
                    }
                } else {
                    buttonUpload.Enabled = true;
                    Log("Error login:");
                    Log(MainClass.ErrorMessage);
                }
            }
            else {
                buttonUpload.Enabled = true;
                Log("Check connection:");
                Log(MainClass.ErrorMessage);
            }
        }

        public async void SendFiles(string pack_id)
        {
            BusyStatus(true);

            string[] chunks = Directory.GetFiles(_tmpPath, "chunk_" + _gameID + "_*.tmp", SearchOption.TopDirectoryOnly);
            foreach (string fPath in chunks)
            {
                string fName = Path.GetFileName(fPath);
                Log("Send: " + fName);

                string pack_num = fName.Replace("chunk_" + _gameID + "_", "").Replace(".tmp", "");
                byte[] fileBuffer = File.ReadAllBytes(fPath);

                await _api.UploadChunkFile(fName, _gameID.ToString(), pack_id, pack_num, fileBuffer);
            }

            BusyStatus(false);
            Log("Done.");
        }


        /// <summary>
        /// Clear
        /// </summary>
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Чистим файлы
            string[] files_zip = Directory.GetFiles(_tmpPath, @"send_pack_*.zip", SearchOption.TopDirectoryOnly);
            foreach (string s in files_zip)
            {
                Log($"Delete file: {s}");
                @File.Delete(s);
            }
            string[] chunks = Directory.GetFiles(_tmpPath, @"chunk_*.tmp", SearchOption.TopDirectoryOnly);
            foreach (string s in chunks)
            {
                Log($"Delete file: {s}");
                @File.Delete(s);
            }
        }

        /// <summary>
        /// Срабатывание таймера при работе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onTimerEvent(object sender, EventArgs e)
        {
            progressBar1.Value += 10;
            if (progressBar1.Value >= 100) progressBar1.Value = 0;
            progressBar1.Update();
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxSavePassword.Checked)
            {
                Properties.Settings.Default.form_login = textBoxLogin.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxSavePassword.Checked)
            {
                Properties.Settings.Default.form_password = textBoxPassword.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void textBoxGameID_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.from_game_id = textBoxGameID.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxBuildFolder_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.form_folder = textBoxBuildFolder.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.from_description = textBoxDescription.Text;
            Properties.Settings.Default.Save();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxLogs.Text = "";
        }

        private void textBoxLogs_TextChanged(object sender, EventArgs e)
        {
            textBoxLogs.SelectionStart = textBoxLogs.TextLength;
            textBoxLogs.ScrollToCaret();
        }

        private void checkBoxReleased_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.form_released = checkBoxReleased.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
