namespace SQLSharpEditor
{
    partial class frEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frEditor));
            gbQuery = new GroupBox();
            rtbQuery = new RichTextBox();
            gbBd = new GroupBox();
            dgvSQL = new DataGridView();
            statusBd = new StatusStrip();
            toolStripStatusBd = new ToolStripStatusLabel();
            menuStripTools = new MenuStrip();
            msArchiver = new ToolStripMenuItem();
            msAbout = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            msRun = new ToolStripMenuItem();
            msSave = new ToolStripMenuItem();
            gbQuery.SuspendLayout();
            gbBd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSQL).BeginInit();
            statusBd.SuspendLayout();
            menuStripTools.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gbQuery
            // 
            gbQuery.Controls.Add(rtbQuery);
            gbQuery.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gbQuery.Location = new Point(12, 48);
            gbQuery.Name = "gbQuery";
            gbQuery.Size = new Size(731, 239);
            gbQuery.TabIndex = 0;
            gbQuery.TabStop = false;
            gbQuery.Text = "Query";
            // 
            // rtbQuery
            // 
            rtbQuery.BackColor = Color.WhiteSmoke;
            rtbQuery.DetectUrls = false;
            rtbQuery.Location = new Point(6, 22);
            rtbQuery.Name = "rtbQuery";
            rtbQuery.RightToLeft = RightToLeft.No;
            rtbQuery.Size = new Size(722, 211);
            rtbQuery.TabIndex = 1;
            rtbQuery.Text = "";
            rtbQuery.TextChanged += rtbQuery_TextChanged;
            // 
            // gbBd
            // 
            gbBd.Controls.Add(dgvSQL);
            gbBd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gbBd.Location = new Point(13, 320);
            gbBd.Name = "gbBd";
            gbBd.Size = new Size(730, 240);
            gbBd.TabIndex = 2;
            gbBd.TabStop = false;
            gbBd.Text = "Banco de Dados";
            // 
            // dgvSQL
            // 
            dgvSQL.BackgroundColor = Color.WhiteSmoke;
            dgvSQL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSQL.Dock = DockStyle.Fill;
            dgvSQL.GridColor = Color.WhiteSmoke;
            dgvSQL.Location = new Point(3, 19);
            dgvSQL.Name = "dgvSQL";
            dgvSQL.RowTemplate.Height = 25;
            dgvSQL.Size = new Size(724, 218);
            dgvSQL.TabIndex = 0;
            // 
            // statusBd
            // 
            statusBd.Items.AddRange(new ToolStripItem[] { toolStripStatusBd });
            statusBd.Location = new Point(0, 569);
            statusBd.Name = "statusBd";
            statusBd.Size = new Size(755, 22);
            statusBd.SizingGrip = false;
            statusBd.TabIndex = 3;
            statusBd.Text = "stausbd";
            // 
            // toolStripStatusBd
            // 
            toolStripStatusBd.Name = "toolStripStatusBd";
            toolStripStatusBd.Size = new Size(0, 17);
            // 
            // menuStripTools
            // 
            menuStripTools.BackColor = SystemColors.Control;
            menuStripTools.Dock = DockStyle.None;
            menuStripTools.Items.AddRange(new ToolStripItem[] { msArchiver, msAbout });
            menuStripTools.Location = new Point(0, 1);
            menuStripTools.Name = "menuStripTools";
            menuStripTools.Size = new Size(64, 24);
            menuStripTools.TabIndex = 4;
            // 
            // msArchiver
            // 
            msArchiver.Image = Properties.Resources.iconArchiver;
            msArchiver.Name = "msArchiver";
            msArchiver.Size = new Size(28, 20);
            msArchiver.ToolTipText = "Arquivo";
            // 
            // msAbout
            // 
            msAbout.Image = Properties.Resources.iconAbout;
            msAbout.Name = "msAbout";
            msAbout.Size = new Size(28, 20);
            msAbout.ToolTipText = "Sobre";
            msAbout.Click += msAbout_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { msRun, msSave });
            menuStrip1.Location = new Point(0, 22);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(184, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // msRun
            // 
            msRun.Image = Properties.Resources.iconRun;
            msRun.Name = "msRun";
            msRun.Size = new Size(28, 20);
            msRun.ToolTipText = "Run";
            msRun.Click += msRun_Click;
            // 
            // msSave
            // 
            msSave.Image = Properties.Resources.iconSave;
            msSave.Name = "msSave";
            msSave.Size = new Size(28, 20);
            msSave.ToolTipText = "Save";
            msSave.Click += msSave_Click;
            // 
            // frEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(755, 591);
            Controls.Add(statusBd);
            Controls.Add(menuStripTools);
            Controls.Add(menuStrip1);
            Controls.Add(gbBd);
            Controls.Add(gbQuery);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "frEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SQL Sharp Editor - Editor SQL in C#";
            Load += frEditor_Load;
            Shown += frEditor_Shown;
            gbQuery.ResumeLayout(false);
            gbBd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSQL).EndInit();
            statusBd.ResumeLayout(false);
            statusBd.PerformLayout();
            menuStripTools.ResumeLayout(false);
            menuStripTools.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbQuery;
        private GroupBox gbBd;
        private DataGridView dgvSQL;
        private RichTextBox rtbQuery;
        private StatusStrip statusBd;
        private ToolStripStatusLabel toolStripStatusBd;
        private MenuStrip menuStripTools;
        private ToolStripMenuItem msArchiver;
        private ToolStripMenuItem msAbout;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem msRun;
        private ToolStripMenuItem msSave;
    }
}