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
using TrabalhoPOO.Classes;

namespace TrabalhoPOO
{
    public partial class Form1 : Form
    {
        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
            listar();
        }

        private void listar() {
            try{
                dgv_contatos.DataSource = Contato.listarContatos();
            }
            catch (Exception) {
                txt_return.Text = "Listagem Falhou! Verifique a conexão com o banco";
            }
        }

        private void dgv_contatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            Contato contato = getRow(senderGrid, e);

            switch (senderGrid.Columns[e.ColumnIndex].Name)
            {
                //Evento de Click no botão de atualizar
                case "btn_atualizar" when (e.RowIndex >= 0):
                    //Metodo para atualizar 
                    txt_return.Text = contato.atualizarContato();
                    listar();
                    break;
                //Evento de Click no botão de remover
                case "btn_remover" when (e.RowIndex >= 0):
                    //Metodo para remover
                    txt_return.Text = contato.removerContato();
                    listar();
                    break;
               default:
                    txt_return.Text = "Erro, opção invalida: "+ senderGrid.Columns[e.ColumnIndex].Name;
                    break;
            }
            verificaRetorno();
        }

        private Contato getRow(DataGridView senderGrid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Contato contato = new Contato(
                senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(),
                senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(),
                senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString(),
                int.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString())
                );
                return contato;
            }
            return null;
        }

        //Cadastrar novo Contato
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato(txt_nome.Text, txt_telefone.Text, txt_celular.Text);
            txt_return.Text = contato.cadastrarContato();
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
