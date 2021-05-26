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
    public class Contato : Conexao
    {
        
        public int? id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public int idUsuario { get; set; }

        public Contato() {

        }

        public Contato(int? id, string nome, string telefone, string celular, int idUsuario)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.celular = celular;
            this.idUsuario = idUsuario;
        }

        //Estava em Usuario
        public static List<Contato> listarContatos(int idUsuario)
        {
            List<Contato> contatos = new List<Contato>();
            using (IDbConnection conexao = conectar())
            {
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "Select id, nome, telefone, celular from contatos where id_usuario = " + idUsuario;
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
                            contato.idUsuario = Convert.ToInt32(leitor["id_usuario"].ToString());

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

        protected string atualizarContato() {
            using (IDbConnection conexao = conectar())
            {
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try {
                        cmd.CommandText = "UPDATE contatos SET nome = " + this.nome + ", telefone = " + this.telefone + ", celular = " + this.celular + " where id = " + this.id;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 60000;

                        IDataReader leitor = cmd.ExecuteReader();

                        leitor.Close();

                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        return "Atualizado com sucesso!";
                    }
                    catch (Exception error) {
                        System.Diagnostics.Debug.WriteLine("Erro: " + error.ToString());
                        return "Falha ao atualizar!";
                    }
                    finally {
                        conexao.Close();
                    }
                }
            }
        }

        protected string removerContato() {
            using (IDbConnection conexao = conectar())
            {
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "DELETE  from contatos WHERE id = " + this.id;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 60000;

                        IDataReader leitor = cmd.ExecuteReader();

                        leitor.Close();

                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        return "Deletado com sucesso!";
                    }
                    catch (Exception error)
                    {
                        System.Diagnostics.Debug.WriteLine("Erro: " + error.ToString());
                        return "Falha ao deletar!";
                    }
                    finally
                    {
                        conexao.Close();
                    }
                }
            }
        }
        protected string cadastrarContato() {
            using (IDbConnection conexao = conectar())
            {
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO contatos (nome, telefone, celular, id_usuario) values ("+this.nome+", "+this.telefone+", "+this.celular+", "+this.idUsuario+")";
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 60000;

                        IDataReader leitor = cmd.ExecuteReader();

                        leitor.Close();

                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        return "Inserido com sucesso!";
                    }
                    catch (Exception error)
                    {
                        System.Diagnostics.Debug.WriteLine("Erro: " + error.ToString());
                        return "Falha ao inserir!";
                    }
                    finally
                    {
                        conexao.Close();
                    }
                }
            }
        }

    }
}
