using System;
using Npgsql;

class ExcluirFuncionario
{
    public static void Excluir()
    {
        Console.Write("Digite o ID do funcionário: ");
        int id = int.Parse(Console.ReadLine());

        string conexao = "Host=localhost;Username=postgres;Password=123456;Database=empresa";

        NpgsqlConnection conn = new NpgsqlConnection(conexao);
        conn.Open();

        string sql = "DELETE FROM funcionarios WHERE id = @id";

        NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);

        int linhasAfetadas = cmd.ExecuteNonQuery();

        if (linhasAfetadas > 0)
        {
            Console.WriteLine("Funcionário excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("ID não encontrado.");
        }

        conn.Close();
    }
}
