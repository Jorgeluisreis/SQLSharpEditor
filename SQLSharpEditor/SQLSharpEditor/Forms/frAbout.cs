using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLSharpEditor.Forms
{
    public partial class frAbout : Form
    {

        public frAbout()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impede o redimensionamento
        }

        private void llabelJorgeLuisReis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("cmd", $"/c start https://github.com/Jorgeluisreis");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Erro ao abrir o link: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}