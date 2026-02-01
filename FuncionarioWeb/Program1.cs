using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

string conexao =
    "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=empresa";


// 🔹 CADASTRAR
app.MapPost("/cadastrar", async (Funcionario f) =>
{
    using var conn = new NpgsqlConnection(conexao);
    conn.Open();

    string sql =
        "INSERT INTO funcionarios (nome, cargo, salario) VALUES (@nome, @cargo, @salario)";
    using var cmd = new NpgsqlCommand(sql, conn);

    cmd.Parameters.AddWithValue("nome", f.Nome);
    cmd.Parameters.AddWithValue("cargo", f.Cargo);
    cmd.Parameters.AddWithValue("salario", f.Salario);

    cmd.ExecuteNonQuery();

    return Results.Ok();
});


// 🔹 LISTAR
app.MapGet("/listar", () =>
{
    var lista = new List<Funcionario>();

    using var conn = new NpgsqlConnection(conexao);
    conn.Open();

    string sql = "SELECT id, nome, cargo, salario FROM funcionarios";
    using var cmd = new NpgsqlCommand(sql, conn);
    using var reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        lista.Add(new Funcionario
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Cargo = reader.GetString(2),
            Salario = reader.GetInt32(3)
        });
    }

    return Results.Json(lista);
});


// 🔹 EXCLUIR
app.MapDelete("/excluir/{id}", (int id) =>
{
    using var conn = new NpgsqlConnection(conexao);
    conn.Open();

    string sql = "DELETE FROM funcionarios WHERE id = @id";
    using var cmd = new NpgsqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("id", id);

    int linhas = cmd.ExecuteNonQuery();

    return linhas > 0 ? Results.Ok() : Results.NotFound();
});

app.Run();


// 🔹 CLASSE
class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public int Salario { get; set; }
}
