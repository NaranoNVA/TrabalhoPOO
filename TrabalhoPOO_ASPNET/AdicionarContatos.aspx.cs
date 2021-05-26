using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabalhoPOO.Classes;

namespace TrabalhoPOO_ASPNET
{
    public partial class AdicionarContatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // listarUsuarios();
        }

        private void listarUsuarios()
        {
           /* List<Contato> contatos = new List<Contato>();
            for (int i = 0; i <= 5; i++)
            {
                Contato contato = new Contato();
                contato.nome = "Teste" + i;
                contato.celular = "Celular" + i;
                contato.telefone = "Telefone" + i;
                contato.id = i;
                contatos.Add(contato);
            }

            contatos = TrabalhoPOO.Classes.Contato.listarContatos();
            gdvContatos.DataSource = contatos;
            gdvContatos.DataBind();*/
        }
    }
}