$('#cpf-vacinado').on("keyup", function (event) {
    var cpf = document.getElementById("cpf-vacinado").value;
    var length = document.getElementById("cpf-vacinado").value.length;
    var containerInserirVacinado = document.getElementById("container-inserir-vacinado");
    var containerInformacoesPaciente = document.getElementById("container-informacoes-paciente");

    if (event.keyCode != 32 && event.keyCode != 8 && event.keyCode != 46) {
        if (length === 3 || length === 7)
        {
            document.getElementById("cpf-vacinado").value = document.getElementById("cpf-vacinado").value + ".";
        }
        else if (length === 11)
        {
            document.getElementById("cpf-vacinado").value = document.getElementById("cpf-vacinado").value + "-";
        }
    }

    if (length === 14)
    {        
        if (containerInserirVacinado.style.display === "none") {
            getInformacoesPaciente(cpf);
        }
    }
    else
    {
        containerInserirVacinado.style.display = "none";
        containerInformacoesPaciente.style.display = "none";
    }
});

function getInformacoesPaciente(cpf) {
    $.ajax({
        url: '/Covid/GetInformacoesPaciente?cpf=' + cpf,
        type: 'GET',
        contentType: 'application/json;',
        success: function (obj) {
            document.getElementById("input-nome-paciente-inserir-vacinado").value = obj.paciente.nome;
            document.getElementById("input-rg-paciente-inserir-vacinado").value = obj.paciente.rg;
            document.getElementById("input-cpf-paciente-inserir-vacinado").value = obj.paciente.cpf;
            document.getElementById("input-cns-paciente-inserir-vacinado").value = obj.paciente.cns;

            document.getElementById("container-inserir-vacinado").style.display = "block";
            document.getElementById("container-informacoes-paciente").style.display = "block";
        },
        error: function () {
            window.alert("Paciente não encontrado!");
            document.getElementById("container-inserir-vacinado").style.display = "none";
            document.getElementById("container-informacoes-paciente").style.display = "none";
        }
    });
}