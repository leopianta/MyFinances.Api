using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Core.Commands
{
   public class CommandResult <T> where T: class
    {
        public List<string> Notificacoes { get; set; }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public T ObjetoResposta { get; set; }

        public CommandResult(string mensagem, bool sucesso, T objetoResposta)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;
            ObjetoResposta = objetoResposta;
            Notificacoes = new List<string>();
        }

        public void AdicionarNotificacao(string notificacao)
        {
            if (Notificacoes == null)
                Notificacoes = new List<string>();

            Notificacoes.Add(notificacao);
        }
    }
}
