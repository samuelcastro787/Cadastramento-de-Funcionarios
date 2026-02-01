using System;

static class Menu
{
    public static void Mostrar()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("SISTEMA DE CADASTRAMENTO DE FUNCIONARIOS");
        Console.WriteLine("[1] Cadastrar");
        Console.WriteLine("[2] Mostrar Funcionarios");
        Console.WriteLine("[3] Excluir Funcionario");
        Console.WriteLine("[0] Sair do Sistema");
        Console.WriteLine("========================================");
        Console.Write("Digite um numero: ");
    }
}
