namespace SQLSharpEditor
{
    partial class frLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frLogin));
            lbUsername = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            lbPassword = new Label();
            btLogin = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Location = new Point(172, 43);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(63, 15);
            lbUsername.TabIndex = 0;
            lbUsername.Text = "Username:";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(142, 61);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(124, 23);
            tbUsername.TabIndex = 1;
            tbUsername.Click += tbUsername_Click;
            tbUsername.Enter += tbUsername_Enter;
            tbUsername.KeyDown += tbUsername_KeyDown;
            tbUsername.Leave += tbUsername_Leave;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(142, 105);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(124, 23);
            tbPassword.TabIndex = 2;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.Click += tbPassword_Click;
            tbPassword.Enter += tbPassword_Enter;
            tbPassword.KeyDown += tbPassword_KeyDown;
            tbPassword.Leave += tbPassword_Leave;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(174, 87);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(60, 15);
            lbPassword.TabIndex = 3;
            lbPassword.Text = "Password:";
            // 
            // btLogin
            // 
            btLogin.Location = new Point(159, 134);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(88, 23);
            btLogin.TabIndex = 4;
            btLogin.Text = "Login";
            btLogin.UseVisualStyleBackColor = true;
            btLogin.Click += btLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icon;
            pictureBox1.Location = new Point(188, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 34);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // frLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(408, 165);
            Controls.Add(pictureBox1);
            Controls.Add(btLogin);
            Controls.Add(lbPassword);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(lbUsername);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Editor SQL in C#";
            Load += frLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbUsername;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Label lbPassword;
        private Button btLogin;
        private PictureBox pictureBox1;
    }
}