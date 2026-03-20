namespace ContactSystem
{

    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Contatos> c = new List<Contatos>();
            int opcao;
            bool validacaoEntrada


            do
            {
                Console.WriteLine("-----Menu-----");
                Console.WriteLine("1 - Criar novo contato.");
                Console.WriteLine("2 - Lista de contatos.");
                Console.WriteLine("3 - Editar contatos.");
                Console.WriteLine("4 - Novos contatos.");
                validacaoEntrada = int.TryParse(Console.ReadLine(), out opcao);
            } while (validacaoEntrada is not true);


            

        }
    }
}