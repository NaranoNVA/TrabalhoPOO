using AgendaTelefonica.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'listaContatosDataSet.contatos'. Você pode movê-la ou removê-la conforme necessário.
            this.contatosTableAdapter.Fill(this.listaContatosDataSet.contatos);

        }

        //Cadastros
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text, telefone = txt_telefone.Text, celular  = txt_celular.Text;
            if (nome != "" && telefone != "" && celular != "")
            {
                txt_return.Text = cadastrarContato(nome, telefone, celular);
            }
            verificaRetorno();
        }

        public String cadastrarContato(string nome, string telefone, string celular)
        {
            Conexao conexao = new Conexao();

            SqlCommand query = new SqlCommand();
            query.CommandText = "INSERT INTO contatos (nome, telefone, celular) values (@nome, @telefone, @celular)";
            query.Parameters.AddWithValue("@nome", nome);
            query.Parameters.AddWithValue("@telefone", telefone);
            query.Parameters.AddWithValue("@celular", celular);

            try
            {
                query.Connection = conexao.conectar();
                query.ExecuteNonQuery();

                conexao.desconectar();

                return "Contato cadastrado com sucesso!";
            }
            catch (SqlException error)
            {
                conexao.desconectar();
                return "Erro: " + error.ToString();
            }

        }

        //Listar
        private void listar()
        {
            try
            {
                dgv_contatos.DataSource = listarContatos();
            }
            catch (Exception)
            {
                txt_return.Text = "Listagem Falhou! Verifique a conexão com o banco";
            }
        }
        public static DataTable listarContatos()
        {

            Conexao conexao = new Conexao();

            SqlCommand query = new SqlCommand();
            query.CommandText = "Select id, nome, telefone, celular from contatos";


            try
            {
                query.Connection = conexao.conectar();
                query.ExecuteNonQuery();

                //Cria DataTable
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = query;
                DataTable contatos = new DataTable();
                adapter.Fill(contatos);

                conexao.desconectar();

                return contatos;
            }
            catch (SqlException error)
            {
                Console.WriteLine("Erro: " + error.ToString());
                conexao.desconectar();
            }


            return null;
        }

        //Alterar
        public String atualizarContato(int id, string nome, string telefone, string celular)
        {
            if (id != -1 && nome != null && telefone != null && celular != null)
            {
                Conexao conexao = new Conexao();

                SqlCommand query = new SqlCommand();
                query.CommandText = "UPDATE contatos SET nome = @nome, telefone = @telefone, celular = @celular where id = @id";
                query.Parameters.AddWithValue("@nome", nome);
                query.Parameters.AddWithValue("@telefone", telefone);
                query.Parameters.AddWithValue("@celular", celular);
                query.Parameters.AddWithValue("@id", id);

                try
                {
                    query.Connection = conexao.conectar();
                    query.ExecuteNonQuery();

                    conexao.desconectar();

                    return "Contato atualizado com sucesso!";
                }
                catch (SqlException error)
                {
                    conexao.desconectar();
                    return "Erro: " + error.ToString();
                }
            }

            return "Erro: Preencha dados validos";
        }

        //Remover
        public String removerContato(int id, string nome, string telefone, string celular)
        {
            if (id != -1 && nome != null && telefone != null && celular != null)
            {
                Conexao conexao = new Conexao();

                SqlCommand query = new SqlCommand();

                query.CommandText = "DELETE  from contatos WHERE id = @id";
                query.Parameters.AddWithValue("@id", id);

                try
                {
                    query.Connection = conexao.conectar();
                    query.ExecuteNonQuery();

                    conexao.desconectar();

                    return "Contato excluido com sucesso!";
                }
                catch (SqlException error)
                {
                    conexao.desconectar();
                    return "Erro: " + error.ToString();
                }
            }

            return "Erro: Selecione um contato para Excluir";
        }

        //Outros
        private void dgv_contatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            string nome = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(),
                telefone = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(),
                celular = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();

            switch (senderGrid.Columns[e.ColumnIndex].Name)
            {

                //Evento de Click no botão de atualizar
                case "Atualizar" when (e.RowIndex >= 0):
                    //Metodo para atualizar 
                    txt_return.Text = atualizarContato(id, nome, telefone, celular);
                    listar();
                    break;

                //Evento de Click no botão de remover
                case "Remover" when (e.RowIndex >= 0):
                    //Metodo para remover

                    txt_return.Text = removerContato(id, nome, telefone, celular);
                    listar();
                    break;
            }

            verificaRetorno();

        }

        private void verificaRetorno()
        {
            if (txt_return.Text.Contains("Erro"))
            {
                txt_return.ForeColor = Color.Red;
            }
            else
            {
                txt_return.ForeColor = Color.Green;
            }
        }
    }
}
