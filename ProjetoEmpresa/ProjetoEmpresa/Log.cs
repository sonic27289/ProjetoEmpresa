using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEmpresa
{
    class Log
    {
        private DateTime dtAcesso;
        private Usuario usuario;
        private bool tipoAcesso;

        public bool TipoAcesso { get => tipoAcesso; set => tipoAcesso = value; }
        public DateTime DtAcesso { get => dtAcesso; }
        internal Usuario Usuario { get => usuario; set => usuario = value; }

        public Log(DateTime dtAcesso, Usuario usuario)
        {
            this.dtAcesso = dtAcesso;
            this.usuario = usuario;
            tipoAcesso = false;
            foreach(Ambiente ambiente in usuario.Ambientes)
            {
                foreach(Log log in ambiente.Logs)
                {
                    if (this.Equals(log))
                    {
                        tipoAcesso = true;
                    }
                }
            }
        }
        public Log()
            :this (DateTime.Now, new Usuario())
        {
            tipoAcesso = false;
        }
        public override string ToString()
        {
            return "Data de Acesso: " + dtAcesso + ", Usuário: " + usuario.ToString() + ", Acesso: " + (tipoAcesso ? "Autorizado" : "Negado");
        }
    }
}
