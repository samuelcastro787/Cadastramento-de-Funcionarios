using System;
using Npgsql;

static class Cadastro
{
    static string conexao =
        "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=empresa";

    public static void CadastrarFuncionario()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Cargo: ");
        string cargo = Console.ReadLine();

        Console.Write("Salario: ");
        int salario = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(conexao))
        {
            conn.Open();

            string sql =
                "INSERT INTO funcionarios (nome, cargo, salario) VALUES (@nome, @cargo, @salario)";
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("cargo", cargo);
                cmd.Parameters.AddWithValue("salario", salario);

                cmd.ExecuteNonQuery();
            }
        }

        Console.WriteLine("--------------------");
        Console.WriteLine("FUNCIONÁRIO CADASTRADO!");
    }
}
