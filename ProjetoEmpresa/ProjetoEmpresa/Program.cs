using System;

namespace ProjetoEmpresa
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            int opcao;
            /* "Download" */
            Cadastro cadastro = new Cadastro();

            while (!sair)
            {
                Console.WriteLine(" Selecione uma opção: \n 0. Sair \n 1. Cadastrar ambiente \n 2. Consultar ambiente \n 3. Excluir ambiente \n 4. Cadastrar usuario \n 5. Consultar usuario \n " +
                "6. Excluir usuario \n 7. Conceder permissão de acesso ao usuario \n 8. Revogar permissão de acesso ao usuario \n 9. Registar acesso \n 10. Consultar logs de acesso ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    /* "Upload" */
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        Console.WriteLine("Digite o ID do ambiente: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o nome do ambiente");
                        string nome = Convert.ToString(Console.ReadLine());
                        cadastro.adicionarAmbiente(new Ambiente(id, nome));
                        Console.WriteLine("Ambiente Cadastrado !");
                        break;
                    case 2:
                        Console.WriteLine("Digite o ID do ambiente: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(cadastro.pesquisarAmbiente(new Ambiente(id, "")).ToString());
                        break;
                    case 3:
                        Console.WriteLine("Digite o ID do ambiente: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(cadastro.removerAmbiente(new Ambiente(id, "")) ? "Ambiente removido" : "Ambiente não removido");
                        break;
                    case 4:
                        Console.WriteLine("Digite o ID do usuário: ");
                        int usuarioID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o nome do usuário: ");
                        nome = Convert.ToString(Console.ReadLine());
                        cadastro.adicionarUsuario(new Usuario(usuarioID, nome));
                        Console.WriteLine("Usuário Cadastrado !");
                        break;
                    case 5:
                        Console.WriteLine("Digite o ID do usuário: ");
                        usuarioID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(cadastro.pesquisarUsuario(new Usuario(usuarioID, "")).ToString());
                        break;
                    case 6:
                        Console.WriteLine("Digite o ID do usuário: ");
                        usuarioID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(cadastro.removerUsuario(new Usuario(usuarioID, "")).ToString());
                        break;
                    case 7:
                        Console.WriteLine("Digite o ID do ambiente: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o ID do usuário: ");
                        usuarioID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(cadastro.pesquisarUsuario(new Usuario(usuarioID, "")).concederPermissao(cadastro.pesquisarAmbiente(new Ambiente(id, ""))) ? "Permissão concedida" : "Permissão não concedida");
                        break;
                    case 8:
                        Console.WriteLine("Digite o ID do ambiente: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o ID do usuário: ");
                        usuarioID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(cadastro.pesquisarUsuario(new Usuario(usuarioID, "")).revogarPermissao(cadastro.pesquisarAmbiente(new Ambiente(id, ""))) ? "Permissão revogada" : "Permissão não revogada");
                        break;
                    case 9:
                        Console.WriteLine("Digite o ID do ambiente: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o ID do usuário: ");
                        usuarioID = Convert.ToInt32(Console.ReadLine());
                        Usuario usuario = cadastro.pesquisarUsuario(new Usuario(usuarioID, ""));
                        bool registrado = false;
                        foreach(Ambiente ambientes in usuario.Ambientes)
                        {
                            if(ambientes.Id == id)
                            {
                                ambientes.registrarLog(new Log(DateTime.Now, usuario));
                                registrado = true;
                            }
                        }
                        if (registrado == true)
                        {
                            Console.WriteLine("Acesso Registrado !");
                        }
                        else
                        {
                            Console.WriteLine("Acesso não registrado !");
                        }
                        break;
                    case 10:
                        Console.WriteLine("Digite o ID do ambiente: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Ambiente ambiente = cadastro.pesquisarAmbiente(new Ambiente(id, ""));
                        Console.WriteLine(ambiente.ToString() + "\n Consultando Logs... \n Logs:");
                        foreach(Log log in ambiente.Logs)
                        {
                            Console.WriteLine(log.ToString());
                        }
                        break;
                }
            }
        }
    }
}
