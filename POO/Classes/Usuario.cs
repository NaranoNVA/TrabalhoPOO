using AgendaTelefonica.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO.Classes
{
    public class Usuario : Conexao
    {
        public int? id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

        public Usuario(){
        }

        public Usuario(int? id, string nome, string telefone, string celular, string login, string senha) {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.celular = celular;
            this.login = login;
            this.senha = senha;
        }

        protected string logar()
        {
            using (IDbConnection conexao = conectar())
            {
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "Select id, nome, telefone, celular, login where login = " + this.login +" AND senha = "+ this.senha;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 60000;

                        IDataReader leitor = cmd.ExecuteReader();

                        while (leitor.Read())
                        {
                            this.nome = leitor["nome"].ToString();
                            this.celular = leitor["celular"].ToString();
                            this.telefone = leitor["telefone"].ToString();
                            this.id = Convert.ToInt32(leitor["id"].ToString());
                            this.login = leitor["login"].ToString();
                        }

                        leitor.Close();
                        return "Logado com sucesso!";
                    }
                    catch (Exception error)
                    {
                        System.Diagnostics.Debug.WriteLine("Erro: " + error.ToString());
                        return "Erro ao sucesso!";
                    }
                    finally
                    {
                        conexao.Close();
                    }
                }
            }
        }

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


    }
}
