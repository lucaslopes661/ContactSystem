using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem
{
    internal class ContatosFuncoes
    {
        List<Contatos> c = new List<Contatos>();
      
        Contatos co = new Contatos();

        public void Menu()
        {
            int opcaoMenu;
            bool validacaoEntrada;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("-----Menu-----");
                    Console.WriteLine("Você possui "+ c.Count +" Contatos");
                    Console.WriteLine("1 - Criar novo contato.");
                    Console.WriteLine("2 - Lista de contatos.");
                    Console.WriteLine("3 - Editar contatos.");
                    Console.WriteLine("4 - Remover contatos.");
                    Console.WriteLine("0 - Fechar o programa.");
                    validacaoEntrada = int.TryParse(Console.ReadLine(), out opcaoMenu);

                    if (validacaoEntrada is false)
                    {
                        Console.Clear();

                        Console.WriteLine("Digite o número da opção desejada");


                    }

                } while (validacaoEntrada is not true);


                /*switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Selecionada a opção 1");
                        break;
                    case 2:
                        Console.WriteLine("Selecionada a opção 2");
                        break;
                    case 3:
                        Console.WriteLine("Selecionada a opção 3");
                        break;
                    case 4:
                        Console.WriteLine("Selecionada a opção 4");
                        break;
                    default:
                        Console.WriteLine("Selecione uma opção válida.");
                        break;
                }*/
                if (opcaoMenu == 1)
                {
                    AdicionaContato();

                }
                else if (opcaoMenu == 2)
                {
                    ListaContato();
                    Console.WriteLine("Voce selecionou a opcao 2.");


                }
                else
                {
                    Console.WriteLine("Digite uma opção válida.");
                }       
            } while (opcaoMenu != 0);

        }


        public void AdicionaContato()
        {

            Console.Clear();

            Console.WriteLine("Digite o nome do seu contato: ");
            co.nome = Console.ReadLine();

            Console.WriteLine("Digite o número do seu contato: ");
            co.telefone = Console.ReadLine();

            Console.WriteLine("Digite o email do seu contato: ");
            co.email = Console.ReadLine();

            c.Add(co);


        }
        public void ListaContato()
        {

            Console.Clear();

            if (c.Count == 0)
            {
                Console.WriteLine("Você não possui contatos.");

                Console.ReadKey();
            }
            else 
            {

                Console.WriteLine("Sua lista de contatos:");

                for (int i = 0; i < c.Count; i++)
                {
                    Console.WriteLine($"Contato {i}");
                    Console.WriteLine($"Nome: {c[i].nome}");
                    Console.WriteLine($"telefone: {c[i].telefone}");
                    Console.WriteLine($"email: {c[i].email}");
                    Console.WriteLine($"--------------------------");
                }

                Console.ReadKey();

            }

        }
    }
}
