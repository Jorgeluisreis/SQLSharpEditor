namespace SQLSharpEditor.Forms
{
    partial class frAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frAbout));
            pictureBox1 = new PictureBox();
            gbAbout = new GroupBox();
            llabelJorgeLuisReis = new LinkLabel();
            lbAbout = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbAbout.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.SQLSharpEditor;
            pictureBox1.Location = new Point(12, 77);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 198);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // gbAbout
            // 
            gbAbout.BackColor = SystemColors.ButtonFace;
            gbAbout.Controls.Add(llabelJorgeLuisReis);
            gbAbout.Controls.Add(lbAbout);
            gbAbout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gbAbout.ForeColor = SystemColors.ControlText;
            gbAbout.Location = new Point(218, 12);
            gbAbout.Name = "gbAbout";
            gbAbout.Size = new Size(370, 361);
            gbAbout.TabIndex = 1;
            gbAbout.TabStop = false;
            gbAbout.Text = "Sobre";
            // 
            // llabelJorgeLuisReis
            // 
            llabelJorgeLuisReis.AutoSize = true;
            llabelJorgeLuisReis.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            llabelJorgeLuisReis.Location = new Point(98, 199);
            llabelJorgeLuisReis.Name = "llabelJorgeLuisReis";
            llabelJorgeLuisReis.Size = new Size(76, 15);
            llabelJorgeLuisReis.TabIndex = 3;
            llabelJorgeLuisReis.TabStop = true;
            llabelJorgeLuisReis.Text = "Jorgeluisreis";
            llabelJorgeLuisReis.LinkClicked += llabelJorgeLuisReis_LinkClicked;
            // 
            // lbAbout
            // 
            lbAbout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbAbout.Location = new Point(6, 19);
            lbAbout.Name = "lbAbout";
            lbAbout.Size = new Size(339, 339);
            lbAbout.TabIndex = 2;
            lbAbout.Text = resources.GetString("lbAbout.Text");
            lbAbout.Click += lbAbout_Click;
            // 
            // frAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(592, 385);
            Controls.Add(gbAbout);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sobre - Editor SQL in C#";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbAbout.ResumeLayout(false);
            gbAbout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox gbAbout;
        private Label lbAbout;
        private LinkLabel llabelJorgeLuisReis;
    }
}