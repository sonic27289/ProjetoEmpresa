using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEmpresa
{
    class Usuario
    {
        private int id;
        private string nome;
        private List<Ambiente> ambientes;

        public List<Ambiente> Ambientes { get => ambientes; }
        public string Nome { get => nome; set => nome = value; }
        public int Id { get => id; set => id = value; }

        public Usuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            ambientes = new List<Ambiente>();
        }

        public Usuario()
            :this(0, ""){
                ambientes = new List<Ambiente>();
            }
        
        public bool concederPermissao(Ambiente ambiente)
        {
            bool encontrado = false;
            foreach(Ambiente a in ambientes)
            {
                if(a.Id == ambiente.Id)
                {
                    encontrado = true;
                }
            }
            if (encontrado == false)
            {
                ambientes.Add(ambiente);
                return true;
            }
            return false;
        }
        public bool revogarPermissao(Ambiente ambiente)
        {
            foreach(Ambiente a in ambientes)
            {
                if(a.Id == ambiente.Id)
                {
                    ambientes.Remove(a);
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return "Nome: " + nome + ", ID = " + id;
        }
    }
}
