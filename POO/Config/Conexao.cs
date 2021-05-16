using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AgendaTelefonica.Config
{
    public class Conexao
    {
        

        public Conexao()
        {
            
        }

        //Metodo para conexão
        protected static SqlConnection conectar()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ListaContatos;User ID=sa;Password=nvamaster123";
            if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();
                System.Diagnostics.Debug.WriteLine("Conexão aberta");
            }

            return conexao;
        }

        //Metodo para desconectar
        protected static void desconectar()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ListaContatos;User ID=sa;Password=nvamaster123";
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
                System.Diagnostics.Debug.WriteLine("Conexão fechada");
            }
        }

    }
}
