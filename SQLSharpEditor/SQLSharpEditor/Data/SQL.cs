using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing.Text;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace SQLSharpEditor.Data
{

    internal class SQL
    {
        private object lockObj = new object(); // Adicione um objeto de bloqueio


        private string tabelaAtual;
        private SQL conexaoSql;

        private ToolStripMenuItem msSave;

        private string nomeColunaEditada;



        private bool houveAlteracoes = false;
        public bool HouveAlteracoes { get; set; }

        public event EventHandler AlteracoesDetectadas;

        public DataGridView DgvSQL { get; private set; }

        //Edição de cores do DataGridView
        DataGridView dgvSQL = new DataGridView();

        // Cor do fundo do DataGridView
        private Color backgroundColor = Color.WhiteSmoke;

        // Cor da células onde estão os dados, sem conta com o cabeçalho das colunas (célula onde fica o nome delas)
        private Color cellBackColor = Color.WhiteSmoke;

        //Cor da divisão entre as células
        private Color gridColor = Color.Gainsboro;
        //Cor do Cabeçalho (células onde fica o nome das colunas
        private Color columnHeaderBackColor = Color.WhiteSmoke;
        private Color columnHeaderForeColor = Color.Black;

        // Edição das células laterais da tabela
        private Color rowHeadersBackColor = Color.WhiteSmoke;
        private Color rowHeadersForeColor = Color.Black;


        private string Query { get; set; }
        private string LocalBase { get; set; }
        private string Namebase { get; set; }
        private string ConnectionString { get; set; }

        internal SqlDataAdapter adaptador { get; set; }

        internal DataTable dataTable { get; set; } // Alterado de private para internal



        public SQL(DataGridView dgvSQL, string query, string localbase, string namebase, string connectionstring)
        {
            //Corrija a atribuição dos parâmetros ao membros da classe
            this.DgvSQL = dgvSQL;
            this.Query = query;
            this.LocalBase = localbase;
            this.Namebase = namebase;
            this.ConnectionString = connectionstring;
            tabelaAtual = ObterNomeDaTabelaDoBancoDeDados();
            this.HouveAlteracoes = false;
            this.msSave = msSave;

            msSave = new ToolStripMenuItem();
            adaptador = new SqlDataAdapter(query, connectionstring);
            DetectarAlteracoes();

            try
            {
                using (SqlConnection conexaoBD = new SqlConnection(connectionstring))
                {
                    adaptador = new SqlDataAdapter();
                    using (SqlCommand sqlCommand = new SqlCommand(query, conexaoBD))
                    {
                        adaptador.SelectCommand = sqlCommand;

                        // Abra a conexão antes de preencher o DataTable
                        conexaoBD.Open();
                        adaptador.SelectCommand.Connection = conexaoBD;
                        dataTable = new DataTable();
                        adaptador.Fill(dataTable);
                    }
                }

                dgvSQL.DataSource = dataTable;

                SetCoresDataGridView(
                    Color.WhiteSmoke, Color.WhiteSmoke, Color.Gainsboro,
                    Color.WhiteSmoke, Color.Black, Color.WhiteSmoke, Color.Black);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no SQL: " + ex.Message);
            }

            // Adicionar o manipulador de eventos CellValueChanged para atualizar a propriedade Tag
            dgvSQL.CellValueChanged += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewCell cell = dgvSQL.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Tag = cell.Value;
                }
                MarcarAlteracoes(); // Certifique-se de chamar MarcarAlteracoes aqui
                AlteracoesDetectadas?.Invoke(this, EventArgs.Empty);
            };

            // Certifique-se de que o evento AlteracoesDetectadas seja disparado corretamente
            DetectarAlteracoes();
        }

        public void SetCoresDataGridView(
           Color backgroundColor,
           Color cellBackColor,
           Color gridColor,
           Color columnHeaderBackColor,
           Color columnHeaderForeColor,
           Color rowHeadersBackColor,
           Color rowHeadersForeColor)
        {
            this.backgroundColor = backgroundColor;
            this.cellBackColor = cellBackColor;
            this.gridColor = gridColor;
            this.columnHeaderBackColor = columnHeaderBackColor;
            this.columnHeaderForeColor = columnHeaderForeColor;
            this.rowHeadersBackColor = rowHeadersBackColor;
            this.rowHeadersForeColor = rowHeadersForeColor;

            AplicarCoresDataGridView();
        }

        private void AplicarCoresDataGridView()
        {
            // Edição das células da visualização do banco de dados SQL
            DgvSQL.EnableHeadersVisualStyles = false;

            DgvSQL.BackgroundColor = backgroundColor;
            DgvSQL.DefaultCellStyle.BackColor = cellBackColor;
            DgvSQL.GridColor = gridColor;
            DgvSQL.ColumnHeadersDefaultCellStyle.BackColor = columnHeaderBackColor;
            DgvSQL.ColumnHeadersDefaultCellStyle.ForeColor = columnHeaderForeColor;
            DgvSQL.RowHeadersDefaultCellStyle.BackColor = rowHeadersBackColor;
            DgvSQL.RowHeadersDefaultCellStyle.ForeColor = rowHeadersForeColor;


        }
        public DataGridView GetDataGridView()
        {

            return dgvSQL;
        }

        public void injectSQL(string query, string localbase, string namebase, string connectionstring)
        {
            try
            {
                if (query.Trim().StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
                {
                    using (SqlConnection conexao = new SqlConnection(connectionstring))
                    {
                        conexao.Open();

                        using (SqlCommand cm = new SqlCommand(query, conexao))
                        {
                            cm.ExecuteNonQuery();
                            MessageBox.Show("Deletado com sucesso!");
                        }
                    }
                }


                using (SqlConnection conexao = new SqlConnection(connectionstring))
                {
                    adaptador = new SqlDataAdapter(query, conexao);
                    dataTable = new DataTable();

                    // Abra a conexão antes de preencher o DataTable
                    conexao.Open();
                    adaptador.Fill(dataTable);


                    if (dataTable.Rows.Count > 0)
                    {
                        dgvSQL.DataSource = dataTable;
                        dgvSQL.Refresh();
                    }
                }

                // Adicionar o manipulador de eventos CellValueChanged para atualizar a propriedade Tag
                dgvSQL.CellValueChanged += (s, e) =>
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        DataGridViewCell cell = dgvSQL.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        cell.Tag = cell.Value;
                    }
                };

                // Certifique-se de que o evento AlteracoesDetectadas seja disparado corretamente
                DetectarAlteracoes();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no SQL: " + ex.Message);
            }
        }

        private void DetectarAlteracoes()
        {
            if (adaptador.SelectCommand == null)
            {
                MessageBox.Show("O SelectCommand não foi inicializado.");
                return;
            }
        }



        private void MarcarAlteracoes()
        {
            if (this.HouveAlteracoes)
                msSave.Visible = true;
        }



        public void AtualizarBancoDeDados()
        {
            lock (lockObj)
            {
                if (this.HouveAlteracoes)
                {
                    string nomeTabela = tabelaAtual;

                    if (!string.IsNullOrEmpty(nomeTabela))
                    {
                        DataTable schemaTable = GetSchemaTable(nomeTabela, adaptador.SelectCommand.Connection.ConnectionString);

                        if (schemaTable != null)
                        {
                            SqlCommand updateCommand = BuildUpdateCommand(schemaTable);
                            SqlCommand insertCommand = BuildInsertCommand(schemaTable);

                            adaptador.UpdateCommand = updateCommand;
                            adaptador.InsertCommand = insertCommand;

                            adaptador.Update(dataTable);

                            this.HouveAlteracoes = false;
                        }
                    }
                }
            }
        }

        internal bool UpdateTable(DataGridView dgvSQL)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(this.ConnectionString))
                {
                    cn.Open();

                    foreach (DataGridViewRow r in dgvSQL.Rows)
                    {
                        string sql;
                        int idValue = Convert.IsDBNull(r.Cells["Id"].Value) ? 0 : Convert.ToInt32(r.Cells["Id"].Value);

                        using (SqlCommand cmd = new SqlCommand("", cn))
                        {
                            if (idValue == 0)
                            {
                                // Se o ID for 0, gera um número aleatório
                                Random random = new Random();
                                int randomId = random.Next(1, 1000);

                                // Usa o número aleatório como ID
                                r.Cells["Id"].Value = randomId;

                                sql = "INSERT INTO CADASTRO (Id, Nome, Idade) VALUES (@Id, @Nome, @Idade)";
                                cmd.Parameters.AddWithValue("@Id", randomId);
                            }
                            else
                            {
                                sql = "UPDATE CADASTRO SET Nome=@Nome, Idade=@Idade WHERE Id=@Id";

                                // Adiciona o parâmetro @Id apenas se o ID for maior que 0
                                cmd.Parameters.AddWithValue("@Id", idValue);
                            }

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Nome", r.Cells["Nome"].Value ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Idade", r.Cells["Idade"].Value ?? DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 515) // Erro de inserção de valor nulo
                {
                    MessageBox.Show("Ocorreu um erro: A coluna 'Id' não pode ter valor nulo.");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro no banco de dados: " + ex.Message);
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
                return false;
            }
        }


        internal DataTable GetSchemaTable(string tableName, string connectionString)
        {
            var cn = $"Data Source={LocalBase};Initial Catalog={Namebase};Integrated Security=True";
            using (SqlConnection conexao = new SqlConnection(cn))
            {
                try
                {
                    conexao.Open();

                    SqlCommand command = new SqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", conexao);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable schemaTable = new DataTable();
                    adapter.Fill(schemaTable);

                    return schemaTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter a tabela de esquema: {ex.Message}");
                    return null; // Retorno nulo em caso de erro
                }
                finally
                {
                    // Certifique-se de fechar a conexão mesmo em caso de exceção
                    if (conexao.State == ConnectionState.Open)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        internal SqlCommand BuildInsertCommand(DataTable schemaTable)
        {
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = adaptador.SelectCommand.Connection;

            StringBuilder insertSql = new StringBuilder($"INSERT INTO {dgvSQL.Tag} (");

            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();
                insertSql.Append($"{columnName}, ");
                insertCommand.Parameters.Add($"@{columnName}", SqlDbType.VarChar, 255, columnName);
            }

            insertSql.Length -= 2;

            insertSql.Append($") VALUES (");

            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();
                insertSql.Append($"@{columnName}, ");
            }

            insertSql.Length -= 2;

            insertSql.Append(")");

            insertCommand.CommandText = insertSql.ToString();

            return insertCommand;
        }


        internal SqlCommand BuildUpdateCommand(DataTable schemaTable)
        {
            SqlCommand updateCommand = new SqlCommand();
            // Restante do código...
            return updateCommand;
        }

        private string ObterChavePrimariaTabela(DataTable schemaTable)
        {
            foreach (DataRow row in schemaTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString().Equals("ID", StringComparison.OrdinalIgnoreCase))
                {
                    return "ID"; // Assume que a chave primária é sempre "ID"
                }
            }

            // Se não encontrarmos uma coluna chamada "ID", retornamos o primeiro nome de coluna
            return schemaTable.Rows[0]["COLUMN_NAME"].ToString();
        }

        internal string ObterNomeDaTabelaDoBancoDeDados()
        {
            try
            {
                if (dgvSQL.SelectedCells.Count > 0)
                {
                    DataTable dataTable = (DataTable)dgvSQL.DataSource;

                    if (dataTable != null)
                    {
                        // Verifique se a propriedade TableName existe antes de tentar acessá-la
                        if (dataTable.ExtendedProperties.ContainsKey("TableName") && dataTable.ExtendedProperties["TableName"] != null)
                        {
                            return dataTable.ExtendedProperties["TableName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter o nome da tabela: " + ex.Message);
            }

            return null;
        }

    }
}
