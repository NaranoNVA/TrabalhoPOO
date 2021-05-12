using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AgendaTelefonica.Config;

namespace TrabalhoPOO.Classes
{
    class Contato : Conexao
    {
        int id;
        string nome, telefone, celular;

        public Contato(string nome, string telefone, string celular, int id = -1)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.celular = celular;
        }

        public static DataTable listarContatos()
        {
            SqlCommand query = new SqlCommand();
            query.CommandText = "Select id, nome, telefone, celular from contatos";

            try
            {
                query.Connection = conectar();
                query.ExecuteNonQuery();

                //Cria DataTable
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = query;
                DataTable contatos = new DataTable();
                adapter.Fill(contatos);

                desconectar();

                return contatos;
            }
            catch (SqlException error)
            {
                Console.WriteLine("Erro: " + error.ToString());
                desconectar();
            }


            return null;
        }

        public string atualizarContato()
        {
            Conexao conexao = new Conexao();

            SqlCommand query = new SqlCommand();
            query.CommandText = "UPDATE contatos SET nome = @nome, telefone = @telefone, celular = @celular where id = @id";
            query.Parameters.AddWithValue("@nome", this.nome);
            query.Parameters.AddWithValue("@telefone", this.telefone);
            query.Parameters.AddWithValue("@celular", this.celular);
            query.Parameters.AddWithValue("@id", this.id);

            try
            {
                query.Connection = conectar();
                query.ExecuteNonQuery();

                desconectar();

                return "Contato atualizado com sucesso!";
            }
            catch (SqlException error)
            {
                desconectar();
                return "Erro: " + error.ToString();
            }

        }

        public string removerContato()
        {
            Conexao conexao = new Conexao();

            SqlCommand query = new SqlCommand();

            query.CommandText = "DELETE  from contatos WHERE id = @id";
            query.Parameters.AddWithValue("@id", this.id);

            try
            {
                query.Connection = conectar();
                query.ExecuteNonQuery();

                desconectar();

                return "Contato excluido com sucesso!";
            }
            catch (SqlException error)
            {
                desconectar();
                return "Erro: " + error.ToString();
            }

        }

        public string cadastrarContato()
        {
            Conexao conexao = new Conexao();

            SqlCommand query = new SqlCommand();
            query.CommandText = "INSERT INTO contatos (nome, telefone, celular) values (@nome, @telefone, @celular)";
            query.Parameters.AddWithValue("@nome", this.nome);
            query.Parameters.AddWithValue("@telefone", this.telefone);
            query.Parameters.AddWithValue("@celular", this.celular);

            try
            {
                query.Connection = conectar();
                query.ExecuteNonQuery();

                desconectar();

                return "Contato cadastrado com sucesso!";
            }
            catch (SqlException error)
            {
                desconectar();
                return "Erro: " + error.ToString();
            }

        }

    }
}
