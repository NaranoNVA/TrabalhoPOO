using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Classes
{
    public class Mensagem
    {
        public int? id { get; set; }
        public int remetente { get; set; }
        public int destinatario { get; set; }
        public string mensagem { get; set; }

        public Mensagem() {

        }

        public Mensagem(int? id, int remetente, int destinatario, string mensagem) {
            this.id = id;
            this.remetente = remetente;
            this.destinatario = destinatario;
            this.mensagem = mensagem;
        }


    }
}
