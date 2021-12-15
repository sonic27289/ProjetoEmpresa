using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEmpresa
{
    class Cadastro
    {
        private List<Usuario> usuarios;
        private List<Ambiente> ambientes;

        public List<Ambiente> Ambientes { get => ambientes;}
        public List<Usuario> Usuarios { get => usuarios; }

        public Cadastro()
        {
            usuarios = new List<Usuario>();
            ambientes = new List<Ambiente>();
        }
        public void adicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }
        public bool removerUsuario(Usuario usuario)
        {
            Usuario remover = pesquisarUsuario(usuario);
            if(remover.Ambientes.Count == 0 && remover != null)
            {
                Console.WriteLine("Usuário removido.");
                usuarios.Remove(remover);
                return true;
            }
            else
            {
                Console.WriteLine("Usuário não encontrado !");
            }
            return false;
        }
        public Usuario pesquisarUsuario(Usuario usuario)
        {
            foreach(Usuario u in usuarios)
            {
                if(u.Id == usuario.Id)
                {
                    return u;
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado !");
                }
            }
            return null;
        }
        public void adicionarAmbiente(Ambiente ambiente)
        {
            ambientes.Add(ambiente);
        }
        public bool removerAmbiente(Ambiente ambiente)
        {
            Ambiente remover = pesquisarAmbiente(ambiente);
            if(remover != null)
            {
                ambientes.Remove(remover);
                return true;
            }
            
            return false;
        }
        public Ambiente pesquisarAmbiente(Ambiente ambiente)
        {
            foreach(Ambiente a in ambientes)
            {
                if(a.Id == ambiente.Id)
                {
                    return a;
                }
            }
            return null;
        }
        public void Upload()
        {

        }
        public void Download()
        {

        }
    }
}
