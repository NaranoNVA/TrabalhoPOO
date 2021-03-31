using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AgendaTelefonica.Config
{
    class Conexao
    {
        SqlConnection conexao = new SqlConnection();

        public Conexao()
        {

            conexao.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ListaContatos;User ID=sa;Password=44554455";

        }

        //Metodo para conexão
        public SqlConnection conectar()
        {

            if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();
            }

            return conexao;
        }

        //Metodo para desconectar
        public void desconectar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

    }
}
