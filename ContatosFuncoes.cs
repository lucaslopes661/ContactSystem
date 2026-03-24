using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactSystem
{
    internal class ContatosFuncoes
    {
        List<Contatos> c = new List<Contatos>();

        string caminho = "C:\\Users\\Lucas\\Desktop\\vs\\ContactSystem";


        public void Menu()
        {
            CarregaContatos();

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
                    Console.WriteLine(opcaoMenu);

                    if (validacaoEntrada is false)
                    {
                        Console.Clear();

                        Console.WriteLine("Digite o número da opção desejada");


                    }

                } while (validacaoEntrada is not true);


                switch (opcaoMenu)
                {
                    case 1:
                        AdicionaContato();
                        break;
                    case 2:
                        ListaContato();
                        break;
                    case 3:
                        EditaContato();
                        break;
                    case 4:
                        RemoverContato();
                        break;
                    case 0:
                        Console.WriteLine("Programa encerrado.");

                        Console.WriteLine("Clique qualquer tecla para fechar");

                        break;
                    default:
                        Console.WriteLine("Selecione uma opção válida.");
                        break;
                }
                /*if (opcaoMenu == 1)
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
                } */   
            } while (opcaoMenu != 0);

        }


        public void AdicionaContato()
        {

            Contatos co = new Contatos();

            Console.Clear();

            Console.WriteLine("Digite o nome do seu contato: ");
            co.nome = Console.ReadLine();

            Console.WriteLine("Digite o número do seu contato: ");
            co.telefone = Console.ReadLine();

            Console.WriteLine("Digite o email do seu contato: ");
            co.email = Console.ReadLine();

            try
            {
                c.Add(co);

                Console.WriteLine("Contato salvo com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            SalvaContatos();

            Console.WriteLine("Clique qualquer tecla para retornar ao menu.");
            Console.ReadKey();



        }
        public void ListaContato()
        {

            Console.Clear();

            if (c.Count == 0)
            {
                Console.WriteLine("Você não possui contatos.");
                Console.WriteLine("Clique qualquer tecla para retornar ao menu.");
                Console.ReadKey();
            }
            else 
            {

                Console.WriteLine("Sua lista de contatos:");

                for (int i = 0; i < c.Count; i++)
                {
                    Console.WriteLine($"Contato {i + 1}");
                    Console.WriteLine($"Nome: {c[i].nome}");
                    Console.WriteLine($"telefone: {c[i].telefone}");
                    Console.WriteLine($"email: {c[i].email}");
                    Console.WriteLine($"--------------------------");
                }

                Console.ReadKey();

            }

        }

        public void EditaContato()
        {
            Console.Clear();
            bool opcaoValida;
            bool opcaoValida2;
            int opcaoEdita;
            int contato;
            int contatoCorrigido;

            if (c.Count == 0)
            {
                Console.WriteLine("Você não possui contatos.");
                Console.WriteLine("Clique qualquer tecla para retornar ao menu.");
                Console.ReadKey();
            }
            else
            {
                do {
                    Console.WriteLine("Qual contato deseja editar?");
                    opcaoValida = int.TryParse(Console.ReadLine(), out contato);

                    if (opcaoValida is not true)
                    {
                        Console.WriteLine("Digite o número do contato que deseja editar.");
                    }
                }while (opcaoValida is not true);

                contatoCorrigido = contato - 1;

                do
                {
                    Console.WriteLine("---O que você deseja editar?---");
                    Console.WriteLine("1 - Nome");
                    Console.WriteLine("2 - Telefone");
                    Console.WriteLine("3 - Email");
                    opcaoValida2 = int.TryParse(Console.ReadLine(), out opcaoEdita);

                    if (opcaoValida2 is not true)
                    {
                        Console.WriteLine("Digite o número da opção desejada");
                    }
                } while (opcaoValida2 is not true);


                switch (opcaoEdita)
                {
                    case 1:
                        Console.WriteLine("Digite o novo nome: ");
                        c[contatoCorrigido].nome = Console.ReadLine();
                        Console.WriteLine("Nome editado com sucesso.");
                        break;
                    case 2:
                        Console.WriteLine("Digite o novo telefone: ");
                        c[contatoCorrigido].telefone = Console.ReadLine();
                        Console.WriteLine("Telefone editado com sucesso.");
                        break;
                    case 3:
                        Console.WriteLine("Digite o novo email: ");
                        c[contatoCorrigido].email = Console.ReadLine();
                        Console.WriteLine("Email editado com sucesso. ");
                        break;

                }

                SalvaContatos();

                Console.ReadKey();
            }
        }

        public void RemoverContato()
        {
            Console.Clear();

            int remove;
            bool opcaoValida3;
            int removeCorreto;


            if (c.Count == 0)
            {
                Console.WriteLine("Você não possui contatos.");
                Console.WriteLine("Clique qualquer tecla para retornar ao menu.");
                Console.ReadKey();
            }
            else
            {
                do {
                    Console.WriteLine("Qual contato deseja remover?");
                    opcaoValida3 = int.TryParse(Console.ReadLine(), out remove);

                    if (opcaoValida3 == false)
                    {
                        Console.WriteLine("Digite apenas o número do contato a ser excluido");
                    }
                }while (opcaoValida3 is not true);

                removeCorreto = remove - 1;

                if (removeCorreto < c.Count)
                {
                    c.RemoveAt(removeCorreto);

                    Console.WriteLine("Contato removido com sucesso.");

                    Console.WriteLine("Clique qualquer tecla para retornar ao menu.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Esse contato não existe");

                    Console.WriteLine("Clique qualquer tecla para retornar ao menu.");
                    Console.ReadKey();
                }
            }

            SalvaContatos();
        }

        public void SalvaContatos()
        {
           
            string salvaJson;

            salvaJson = JsonConvert.SerializeObject(c);

            try
            {
                System.IO.File.WriteAllText($"{caminho}\\contatos.json", salvaJson);


            }catch (Exception ex) 
            { 
               Console.WriteLine(ex.Message);
            }



        }

        public void CarregaContatos()
        {
            bool verificaArquivo;

            verificaArquivo = File.Exists($"{caminho}\\contatos.json");

            if (verificaArquivo)
            {
                using (StreamReader sr = new StreamReader($"{caminho}\\contatos.json"))
                {
                    var lerJson = sr.ReadToEnd();
                    var carregaContatos = JsonConvert.DeserializeObject<List<Contatos>>(lerJson);

                    if (carregaContatos == null)
                    {

                    }
                    else
                    {
                        c = carregaContatos;
                    }
                }
            }
            else
            {
                Console.WriteLine("Não há contatos salvos previamente");
            }
            

        }
    }
}
