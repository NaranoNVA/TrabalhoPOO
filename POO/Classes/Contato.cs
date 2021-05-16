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
    [Serializable]
    public class Contato : Conexao
    {
        
        public int? id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }


        public Contato()
        {
           //this.id = id;
           //this.nome = nome;
           //this.telefone = telefone;
           //this.celular = celular;
        }

        public static List<Contato> listarContatos()
        {
            List<Contato> contatos = new List<Contato>();
            using (IDbConnection conexao = conectar()) 
            {
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    //Testar com Get e SET AMANHA
                    try
                    {
                        cmd.CommandText = "Select id, nome, telefone, celular from contatos";
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 60000;

                        IDataReader leitor = cmd.ExecuteReader();

                        while (leitor.Read())
                        {
                            Contato contato = new Contato();
                            contato.nome = leitor["nome"].ToString();
                            contato.celular = leitor["celular"].ToString();
                            contato.telefone = leitor["telefone"].ToString();
                            contato.id = Convert.ToInt32(leitor["id"].ToString());
                                
                            contatos.Add(contato);
                        }

                        leitor.Close();

                        return contatos;
                    }
                    catch (Exception error)
                    {
                        System.Diagnostics.Debug.WriteLine("Erro: " + error.ToString());
                        return contatos;
                    }
                    finally
                    {
                        conexao.Close();
                    }
                }
            }
        }

        public string atualizarContato()
        {
            /*Conexao conexao = new Conexao();

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
            }*/
            return "teasda";
        }

        public string removerContato()
        {
            /*Conexao conexao = new Conexao();

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
            }*/
            return "43211";
        }

        public string cadastrarContato()
        {
            /*Conexao conexao = new Conexao();

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
            }*/
            return "21313";
        }
    }
}
