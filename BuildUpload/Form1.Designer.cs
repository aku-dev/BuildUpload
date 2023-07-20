
namespace BuildUpload
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxGameID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxReleased = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonClear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.buttonMakePackage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBuildFolder = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBoxSavePassword = new System.Windows.Forms.CheckBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxGameID
            // 
            this.textBoxGameID.Location = new System.Drawing.Point(64, 13);
            this.textBoxGameID.Name = "textBoxGameID";
            this.textBoxGameID.Size = new System.Drawing.Size(347, 20);
            this.textBoxGameID.TabIndex = 0;
            this.textBoxGameID.TextChanged += new System.EventHandler(this.textBoxGameID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxReleased);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBoxLogs);
            this.groupBox1.Controls.Add(this.buttonMakePackage);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxBuildFolder);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxGameID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 284);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Build";
            // 
            // checkBoxReleased
            // 
            this.checkBoxReleased.AutoSize = true;
            this.checkBoxReleased.Checked = true;
            this.checkBoxReleased.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReleased.Location = new System.Drawing.Point(417, 15);
            this.checkBoxReleased.Name = "checkBoxReleased";
            this.checkBoxReleased.Size = new System.Drawing.Size(97, 17);
            this.checkBoxReleased.TabIndex = 14;
            this.checkBoxReleased.Text = "Game released";
            this.checkBoxReleased.UseVisualStyleBackColor = true;
            this.checkBoxReleased.CheckedChanged += new System.EventHandler(this.checkBoxReleased_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 253);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(508, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(6, 91);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Clear Files";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.Location = new System.Drawing.Point(6, 120);
            this.textBoxLogs.MaxLength = 65536;
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(508, 127);
            this.textBoxLogs.TabIndex = 11;
            this.textBoxLogs.Text = "Start\r\nBuild";
            this.textBoxLogs.TextChanged += new System.EventHandler(this.textBoxLogs_TextChanged);
            // 
            // buttonMakePackage
            // 
            this.buttonMakePackage.Location = new System.Drawing.Point(386, 91);
            this.buttonMakePackage.Name = "buttonMakePackage";
            this.buttonMakePackage.Size = new System.Drawing.Size(128, 23);
            this.buttonMakePackage.TabIndex = 9;
            this.buttonMakePackage.Text = "Make Package";
            this.buttonMakePackage.UseVisualStyleBackColor = true;
            this.buttonMakePackage.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Build Folder:";
            // 
            // textBoxBuildFolder
            // 
            this.textBoxBuildFolder.Location = new System.Drawing.Point(101, 65);
            this.textBoxBuildFolder.Name = "textBoxBuildFolder";
            this.textBoxBuildFolder.Size = new System.Drawing.Size(332, 20);
            this.textBoxBuildFolder.TabIndex = 6;
            this.textBoxBuildFolder.TextChanged += new System.EventHandler(this.textBoxBuildFolder_TextChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(101, 39);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(413, 20);
            this.textBoxDescription.TabIndex = 3;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Build Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Active Server:";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(101, 71);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.ReadOnly = true;
            this.textBoxUrl.Size = new System.Drawing.Size(413, 20);
            this.textBoxUrl.TabIndex = 5;
            this.textBoxUrl.Text = "http://";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonUpload);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBoxSavePassword);
            this.groupBox2.Controls.Add(this.textBoxPassword);
            this.groupBox2.Controls.Add(this.textBoxLogin);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxUrl);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 126);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upload";
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(386, 97);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(128, 23);
            this.buttonUpload.TabIndex = 10;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(194, 47);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(102, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Show Password";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBoxSavePassword
            // 
            this.checkBoxSavePassword.AutoSize = true;
            this.checkBoxSavePassword.Checked = true;
            this.checkBoxSavePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSavePassword.Location = new System.Drawing.Point(194, 21);
            this.checkBoxSavePassword.Name = "checkBoxSavePassword";
            this.checkBoxSavePassword.Size = new System.Drawing.Size(100, 17);
            this.checkBoxSavePassword.TabIndex = 7;
            this.checkBoxSavePassword.Text = "Save Password";
            this.checkBoxSavePassword.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(64, 45);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(124, 20);
            this.textBoxPassword.TabIndex = 6;
            this.textBoxPassword.Text = "password";
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(64, 19);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(124, 20);
            this.textBoxLogin.TabIndex = 2;
            this.textBoxLogin.TextChanged += new System.EventHandler(this.textBoxLogin_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Login:";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.onTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 439);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Build Uploader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGameID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMakePackage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBuildFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBoxSavePassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxReleased;
    }
}

