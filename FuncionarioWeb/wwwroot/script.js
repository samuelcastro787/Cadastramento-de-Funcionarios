function cadastrar() {
    fetch("/cadastrar", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            nome: nome.value,
            cargo: cargo.value,
            salario: parseInt(salario.value)
        })
    }).then(() => alert("Funcionário cadastrado!"));
}

function listar() {
    fetch("/listar")
        .then(r => r.json())
        .then(dados => {
            lista.innerHTML = "";

            dados.forEach(f => {
                lista.innerHTML += `
                    <div class="funcionario">
                    Nome: ${f.nome}<br>
                    Cargo: ${f.cargo}<br>
                    Salário: R$ ${f.salario}
                    <button onclick="excluir(${f.id})">Excluir</button>
                </div><hr>
                `;
            });
        });
}

function excluir(id) {
    fetch(`/excluir/${id}`, { method: "DELETE" })
        .then(() => listar());
}
