using SQLSharpEditor.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLSharpEditor
{
    public partial class frLogin : Form
    {
        public frLogin()
        {


            InitializeComponent();
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            tbUsername.BackColor = Color.White;
        }

        private void tbUsername_Click(object sender, EventArgs e)
        {
            tbUsername.BackColor = Color.LightYellow;
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.LightYellow;
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.White;
        }

        private void tbPassword_Click(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.LightYellow;
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            tbUsername.BackColor = Color.LightYellow;
        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                tbPassword.Focus();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Login();
            }
        }

        private void Login()
        {
            string user = tbUsername.Text;
            string pass = tbPassword.Text;

            Usernames login = new Usernames(user, pass);

            if (login.checarLogin(user, pass))
            {
                // Usar um diálogo de seleção de arquivo para escolher o arquivo INI
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Arquivos INI|*.ini";
                openFileDialog.Title = "Selecione o arquivo INI";

                try
                {

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string caminhoArquivoIni = openFileDialog.FileName;

                        // Validar e ler o arquivo INI
                        if (File.Exists(caminhoArquivoIni))
                        {
                            // Usando o dicionário criado para ler o INI
                            Dictionary<string, string> camposIni = LerCamposIni(caminhoArquivoIni);

                            // Acessando Dados e checando se as mesmoe existem no Ini já salvas no Dicionário
                            if (camposIni.ContainsKey("NOMEBASE") && camposIni.ContainsKey("LOCALBASE"))
                            {

                                // As atribuindo em variável local os resultados das chaves salvos no Dicioário feito em base do INI
                                string nomeBase = camposIni["NOMEBASE"];
                                string localBase = camposIni["LOCALBASE"];



                                // Validar a conexão com o SQL Server
                                if (ValidarConexaoSqlServer(localBase, nomeBase))
                                {

                                    frEditor editor = new frEditor();
                                    editor.LocalBase = localBase;
                                    editor.NomeBase = nomeBase;
                                    this.Hide();
                                    editor.Show();


                                }
                                else
                                {
                                    MessageBox.Show($"Falha na conexão em:\nLocalBase:{localBase}\nNomeBase: {nomeBase}\n", "Falha na Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("As chaves NOMEBASE e LOCALBASE não foram encontradas.", "Erro nas Chaves", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("O arquivo INI não existe.", "Erro no INI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred in SQL: {ex}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username or Password is Incorret", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static Dictionary<string, string> LerCamposIni(string caminho)
        {
            Dictionary<string, string> camposIni = new Dictionary<string, string>();

            // Cria um dicionário para armazenar as chaves e valores do arquivo INI
            foreach (string linha in File.ReadLines(caminho, Encoding.UTF8))
            {
                // Remove espaços em branco no início e no final da linha
                string linhaTratada = linha.Trim();

                // Ignorar linhas vazias ou comentadas
                if (linhaTratada.Length == 0 || linhaTratada.StartsWith(";") || linhaTratada.StartsWith("#") || linhaTratada.StartsWith("//"))
                    continue;

                // Dividir a linha em chave e valor usando '='
                string[] partes = linhaTratada.Split('=');

                // Verifica se a linha tem o formato chave=valor
                if (partes.Length == 2)
                {
                    // Extrai a chave e o valor, removendo espaços em branco adicionais
                    string chave = partes[0].Trim();
                    string valor = partes[1].Trim();

                    // Adiciona a chave e o valor ao dicionário
                    camposIni[chave] = valor;
                }
            }

            // Retorna o dicionário resultante
            return camposIni;
        }

        static bool ValidarConexaoSqlServer(string localBase, string nomeBase)
        {
            // Configurar a string de conexão com o SQL Server
            string connectionString = $"Data Source={localBase};Initial Catalog={nomeBase};Integrated Security=True";

            try
            {
                // Tentar abrir uma conexão com o SQL Server
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                DialogResult loginBd = MessageBox.Show($"Error SQL: {ex.Message}\n\nDeseja repetir ?", "Erro SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (loginBd == DialogResult.Yes)
                {
                    ValidarConexaoSqlServer(localBase, nomeBase);

                }

                return false; // A conexão falhou
            }

            catch (Exception ex1)
            {
                MessageBox.Show($"Error: {ex1.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // A conexão falhou
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Login(); //Sistema de Login
        }

        private void frLogin_Load(object sender, EventArgs e)
        {

        }
    }
}