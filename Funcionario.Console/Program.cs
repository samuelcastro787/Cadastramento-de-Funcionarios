using System;

class Program
{
    static void Main(string[] args)
    {
        bool sistemaAtivo = true;

        while (sistemaAtivo)
        {
            Menu.Mostrar();

            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Cadastro.CadastrarFuncionario();
            }
            else if (option == 2)
            {
                Listagem.ListarFuncionarios();
            }
            else if (option == 3)
            {
                ExcluirFuncionario.Excluir();
            }
            else if (option == 0)
            {
                sistemaAtivo = false;
                Console.WriteLine("Saindo do Sistema...");
            }
            else
            {
                Console.WriteLine("Opção Inválida");
            }

            Console.WriteLine("\nPressione ENTER para continuar");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
