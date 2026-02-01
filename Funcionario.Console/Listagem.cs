using System;
using Npgsql;

static class Listagem
{
    static string conexao =
        "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=empresa";

    public static void ListarFuncionarios()
    {
        using (var conn = new NpgsqlConnection(conexao))
        {
            conn.Open();

            string sql = "SELECT id, nome, cargo, salario FROM funcionarios";
            using (var cmd = new NpgsqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("Nenhum Funcionário Cadastrado!");
                }
                else
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("LISTA DE FUNCIONÁRIOS");

                    while (reader.Read())
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine("ID: " + reader.GetInt32(0));
                        Console.WriteLine("Nome: " + reader.GetString(1));
                        Console.WriteLine("Cargo: " + reader.GetString(2));
                        Console.WriteLine("Salario: " + reader.GetInt32(3));
                    }
                }
            }
        }
    }
}
