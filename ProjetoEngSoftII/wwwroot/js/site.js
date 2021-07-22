$('#cpf-paciente').on("keyup", function (event) {
    var cpf = document.getElementById("cpf-paciente").value;
    var length = document.getElementById("cpf-paciente").value.length;

    if (event.keyCode != 32 && event.keyCode != 8 && event.keyCode != 46) {
        if (length === 3 || length === 7) {
            document.getElementById("cpf-paciente").value = document.getElementById("cpf-paciente").value + ".";
        }
        else if (length === 11) {
            document.getElementById("cpf-paciente").value = document.getElementById("cpf-paciente").value + "-";
        }
    }
});

$('#rg-paciente').on("keyup", function (event) {
    var cpf = document.getElementById("rg-paciente").value;
    var length = document.getElementById("rg-paciente").value.length;

    if (event.keyCode != 32 && event.keyCode != 8 && event.keyCode != 46) {
        if (length === 2 || length === 6) {
            document.getElementById("rg-paciente").value = document.getElementById("rg-paciente").value + ".";
        }
        else if (length === 10) {
            document.getElementById("rg-paciente").value = document.getElementById("rg-paciente").value + "-";
        }
    }
});

$('#cpf-vacinado').on("keyup", function (event) {
    var cpf = document.getElementById("cpf-vacinado").value;
    var length = document.getElementById("cpf-vacinado").value.length;
    var containerInserirVacinado = document.getElementById("container-inserir-vacinado");
    var containerInformacoesPaciente = document.getElementById("container-informacoes-paciente");

    if (event.keyCode != 32 && event.keyCode != 8 && event.keyCode != 46) {
        if (length === 3 || length === 7) {
            document.getElementById("cpf-vacinado").value = document.getElementById("cpf-vacinado").value + ".";
        }
        else if (length === 11) {
            document.getElementById("cpf-vacinado").value = document.getElementById("cpf-vacinado").value + "-";
        }
    }

    if (length === 14) {
        if (containerInserirVacinado.style.display === "none") {
            getInformacoesPaciente(cpf);
        }
    }
    else {
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

            var tomouPrimeiraDose = obj.tomouPrimeiraDose;
            
            if (tomouPrimeiraDose) {
                var select_dose = document.getElementById("select_dose");
                select_dose.remove(0);

                var marcaVacinaId = obj.marcaVacinaId;
                var select_marca = document.getElementById("select_marca_covid");

                while (document.getElementById("select_marca_covid").length != 1) {
                    for (var i = 0; i < select_marca.length; i++) {
                        if (select_marca.options[i].value != marcaVacinaId)
                            select_marca.remove(i);
                    }
                }

                var mm = '0';
                if (obj.mm < 10) {
                    mm = mm.concat(obj.mm);
                }
                else {
                    mm = obj.mm;
                }

                var dd = '0';
                if (obj.dd < 10) {
                    dd = dd.concat(obj.dd);
                }
                else {
                    dd = obj.dd;
                }

                var data = obj.yyyy + '-' + mm + '-' + dd;
                document.getElementById("data_vacinacao").setAttribute("min", data);
            }
            else {
                var select_dose = document.getElementById("select_dose");
                select_dose.remove(1);
            }
        },
        error: function () {
            window.alert("Paciente não encontrado!");
            document.getElementById("container-inserir-vacinado").style.display = "none";
            document.getElementById("container-informacoes-paciente").style.display = "none";
        }
    });
}