using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao;

        protected List<string> MensagensValidacao
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
        }

        protected bool EhValido
        {
            get { return !MensagensValidacao.Any(); }
        }

        public virtual void Validate()
        {
            LimparMensagensValidacao();
        }

        protected void AdicionarCritica(string mensagem)
        {
            MensagensValidacao.Add(mensagem);
        }

        protected void LimparMensagensValidacao()
        {
            MensagensValidacao.Clear();
        }
    }
}
