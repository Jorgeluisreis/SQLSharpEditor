using SQLSharpEditor.Data;
using SQLSharpEditor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SQLSharpEditor
{


    public partial class frEditor : Form
    {

        #region Dados de Conexão

        private DataGridView DgvSQL;

        private string tabelaAtual; // Certifique-se de que essa variável está corretamente inicializada e atualizada

        private SQL conexaoSql;

        private bool houveAlteracoes = false;

        private bool conexaoBancoDadosConectada = false;

        private System.Windows.Forms.Timer timerStatusConexao;
        public string NomeBase { get; set; }
        public string LocalBase { get; set; }

        public frEditor()
        {

            InitializeComponent();

            DgvSQL = dgvSQL;
            //Timer de conexão
            timerStatusConexao = new System.Windows.Forms.Timer();
            timerStatusConexao.Interval = 1000; // Intervalo de 1 segundo

            // Define o manipulador de eventos do timer
            timerStatusConexao.Tick += (sender, e) => VerificarStatusConexao();

            // Inicia o timer
            timerStatusConexao.Start();

            // Inicializa o status de conexão
            conexaoBancoDadosConectada = false;
            AtualizarStatusConexao();

        }
        #endregion



        private void frEditor_Shown(object sender, EventArgs e)
        {
            msSave.Visible = false;
            msRun.Visible = false;
            VerificarStatusConexao();
        }

        private bool ultimaConexaoBancoDadosConectada = false;

        private void VerificarStatusConexao()
        {
            // Obtém o estado atual da conexão
            bool conexaoBancoDadosAtualConectada = EstadoConexaoBancoDados();

            // Verifica se houve uma mudança no estado da conexão
            if (conexaoBancoDadosAtualConectada != ultimaConexaoBancoDadosConectada)
            {
                // Atualiza a variável que armazena o estado da última conexão
                ultimaConexaoBancoDadosConectada = conexaoBancoDadosAtualConectada;

                // Exibe a mensagem de erro apenas se a conexão foi perdida
                if (!conexaoBancoDadosAtualConectada)
                {
                    AtualizarStatusConexao();
                    ConectarBancoDados();
                }

                // Atualiza o status da conexão
                AtualizarStatusConexao();
            }
        }

        // Este método verifica apenas o estado atual da conexão
        private bool EstadoConexaoBancoDados()
        {
            string nomeBase = this.NomeBase;
            string localBase = this.LocalBase;

            try
            {
                string connectionString = $"Data Source={localBase};Initial Catalog={nomeBase};Integrated Security=True";
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    // Verifica a conexão usando Ping
                    using (var dbCommand = conexao.CreateCommand())
                    {
                        dbCommand.CommandText = "SELECT 1";
                        dbCommand.ExecuteNonQuery();
                    }

                    return true; // A conexão está ativa
                }
            }
            catch (SqlException)
            {
                return false; // A conexão falhou
            }
        }

        private void ConectarBancoDados()
        {
            // infos de NomeBase e LocalBase
            string nomeBase = this.NomeBase;
            string localBase = this.LocalBase;

            string connectionString = $"Data Source={localBase};Initial Catalog={nomeBase};Integrated Security=True";

            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    using (SqlCommand comando = new SqlCommand("SELECT 1", conexao))
                    {
                        comando.ExecuteNonQuery();
                    }

                    conexaoBancoDadosConectada = true;
                }

                // Reinicia o timer após uma reconexão bem-sucedida

            }
            catch (SqlException ex)
            {
                timerStatusConexao.Stop();
                DialogResult erroBd = MessageBox.Show(this, $"Erro ao conectar ao banco de dados:\n{ex.Message}\n\nDeseja reconectar?", "Erro SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                conexaoBancoDadosConectada = false;

                if (erroBd == DialogResult.Yes)
                {
                    ConectarBancoDados();
                }
                else
                {
                    frLogin login = new frLogin();
                    this.Hide();
                    login.Show();
                }
            }

            // Sempre chame a atualização do status após tentar conectar
            timerStatusConexao.Start();
            AtualizarStatusConexao();
        }

        private void ReconectarBd()
        {
            // infos de NomeBase e LocalBase
            string nomeBase = this.NomeBase;
            string localBase = this.LocalBase;

            string connectionString = $"Data Source={localBase};Initial Catalog={nomeBase};Integrated Security=True";

            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    using (SqlCommand comando = new SqlCommand("SELECT 1", conexao))
                    {
                        comando.ExecuteNonQuery();
                    }

                    conexaoBancoDadosConectada = true;
                }
            }
            catch (SqlException ex)
            {
                timerStatusConexao.Stop();
                DialogResult erroBd = MessageBox.Show(this, $"Erro ao conectar ao banco de dados:\n{ex.Message}\n\nDeseja reconectar?", "Erro SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                conexaoBancoDadosConectada = false;

                if (erroBd == DialogResult.Yes)
                {
                    ReconectarBd();
                }

                timerStatusConexao.Start();

            }

            // Sempre chame a atualização do status após tentar conectar
            AtualizarStatusConexao();
        }

        //Atualiza o ToolStrip de Status de conexão do Banco de Dados
        private void AtualizarStatusConexao()
        {
            if (ultimaConexaoBancoDadosConectada)
            {
                toolStripStatusBd.Text = $"Conectado ao Banco de Dados: {NomeBase} em {LocalBase}";
                toolStripStatusBd.ForeColor = Color.Green;
            }
            else
            {
                toolStripStatusBd.Text = "Desconectado do Banco de Dados";
                toolStripStatusBd.ForeColor = Color.Red;
            }
        }


        private void frEditor_Load(object sender, EventArgs e)
        {

            // Verifica a conexão ao carregar o formulário
            ConectarBancoDados();
            VerificarStatusConexao();


            string nomeBase = this.NomeBase;
            string localBase = this.LocalBase;

        }


        private void rtbQuery_TextChanged(object sender, EventArgs e)
        {
            bool temTexto = !string.IsNullOrWhiteSpace(rtbQuery.Text);

            msRun.Visible = temTexto;

            // Salva a posição atual do cursor no RichTextBox
            int posicaoAtual = rtbQuery.SelectionStart;

            //Coloca todo e qualquer texto para maiúsculo
            rtbQuery.Text = rtbQuery.Text.ToUpper();

            // Obtém o texto atual do RichTextBox
            string textoOriginal = rtbQuery.Text;

            // Seleciona todo o texto e redefine a cor padrão para evitar interferências
            rtbQuery.SelectAll();
            rtbQuery.SelectionColor = rtbQuery.ForeColor;

            // Itera sobre cada palavra reservada
            foreach (string palavraReservada in PalavrasReservadas())
            {
                // Constrói um padrão de expressão regular para corresponder à palavra reservada como palavra inteira
                string padraoRegex = @"\b" + Regex.Escape(palavraReservada) + @"\b";

                // Encontra todas as correspondências da palavra reservada no texto usando a expressão regular
                MatchCollection matches = Regex.Matches(textoOriginal, padraoRegex, RegexOptions.IgnoreCase);

                // Para cada correspondência, define a cor da seleção para a cor desejada (azul)
                foreach (Match match in matches)
                {
                    rtbQuery.Select(match.Index, match.Length);
                    rtbQuery.SelectionColor = Color.Blue; // Ou a cor desejada
                }
            }

            // Restaura a posição original do cursor
            rtbQuery.SelectionStart = posicaoAtual;
            rtbQuery.SelectionLength = 0;
            rtbQuery.SelectionColor = rtbQuery.ForeColor; // Restaura a cor padrão para o cursor
        }
        private List<string> PalavrasReservadas()
        {
            return new List<string>
            {
        // Palavras-chave SQL
            "SELECT", "INSERT", "UPDATE", "DELETE", "FROM", "WHERE", "JOIN", "INNER",
            "LEFT", "RIGHT", "OUTER", "GROUP BY", "ORDER BY", "HAVING", "TOP", "AND",
            "OR", "NOT", "IN", "LIKE", "BETWEEN",

            // Palavras reservadas de Identificação
            "CREATE", "ALTER", "DROP", "INDEX", "TABLE", "VIEW", "PROCEDURE",
            "FUNCTION", "TRIGGER", "DATABASE",

            // Controle de Fluxo
            "IF", "ELSE", "BEGIN", "END", "RETURN", "GOTO", "BREAK", "CONTINUE", "WHILE",

            // Transações
            "COMMIT", "ROLLBACK", "BEGIN TRANSACTION", "SET TRANSACTION",

            // Gerenciamento de Usuários e Permissões
            "GRANT", "REVOKE", "DENY", "CREATE LOGIN", "CREATE USER", "ALTER LOGIN",
            "ALTER USER", "DROP LOGIN", "DROP USER",

            // Funções Agregadas
            "COUNT", "SUM", "AVG", "MIN", "MAX"
            };
        }

        private void msAbout_Click(object sender, EventArgs e)
        {
            frAbout sobre = new frAbout();
            sobre.TopMost = true;
            sobre.ShowDialog();
        }

        private void msRun_Click(object sender, EventArgs e)
        {
            string nomeBase = this.NomeBase;
            string localBase = this.LocalBase;
            string query = rtbQuery.Text;
            string connectionString = $"Data Source={localBase};Initial Catalog={nomeBase};Integrated Security=True";

            try
            {
                // Criação da instância da classe SQL
                conexaoSql = new SQL(dgvSQL, query, localBase, nomeBase, connectionString);

                // Adiciona o manipulador de eventos CellValueChanged
                conexaoSql.AlteracoesDetectadas += ConexaoSql_AlteracoesDetectadas;

                // Verifica se a instância foi criada com sucesso
                if (conexaoSql != null)
                {
                    try
                    {


                        conexaoSql.injectSQL(query, localBase, nomeBase, connectionString);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ocorreu um erro no SQL: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro: " + ex.Message);
                    }
                }
            }
            finally
            {
            }
        }


        private void msSave_Click(object sender, EventArgs e)
        {
            if (conexaoSql != null && conexaoSql.HouveAlteracoes)
            {
                // Alterado: Obtenha a tabela de esquema no contexto adequado
                dgvSQL.AllowUserToAddRows = false;
                conexaoSql.UpdateTable(this.dgvSQL);
                dgvSQL.AllowUserToAddRows = true;
                conexaoSql.AtualizarBancoDeDados();

                // Desative o botão de salvar e redefina a flag
                msSave.Visible = false;
                conexaoSql.HouveAlteracoes = false;
            }
        }
        private void MarcarAlteracoes()
        {
            if (conexaoSql != null)
            {
                conexaoSql.HouveAlteracoes = true;

                // Habilitar o botão de salvar quando houver alterações
                if (msSave != null)
                    msSave.Visible = true;
            }
        }

        private void dgvSQL_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSQL.IsCurrentCellDirty)
            {
                dgvSQL.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void ConexaoSql_AlteracoesDetectadas(object sender, EventArgs e)
        {
            MarcarAlteracoes();
        }

        private void msSave_Click_1(object sender, EventArgs e)
        {

        }





    }
}
