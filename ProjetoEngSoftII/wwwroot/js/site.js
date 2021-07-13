var containerInserirVacinado = document.getElementById("container-inserir-vacinado");


$('#buscar-cpf-vacinado').on("click", function () {

    var cpf = document.getElementById("cpf-vacinado").value;

    if (testeCont.style.display === "none") {
        testeCont.style.display = "block";
        txtstart.value = "teste";
    } else {
        testeCont.style.display = "none";
    }

});

$('#buscar-cpf-vacinado').on("click", function () {

    var cpf = document.getElementById("cpf-vacinado").value;

    if (testeCont.style.display === "none") {
        testeCont.style.display = "block";
        txtstart.value = "teste";
    } else {
        testeCont.style.display = "none";
    }

});

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
            containerInserirVacinado.style.display = "block";
            getInformacoesPaciente(cpf);
        }
    }
    else
    {
        containerInserirVacinado.style.display = "none";
    }
});

//function getInformacoesPaciente(cpf) {
//    $.get('/Covid/GetInformacoesPaciente?cpf=' + cpf, {},
//        function (data, status) {
//            if (!data.success) {
//                alert('User ID is invalid!');
//            }
//        });
//}

function getInformacoesPaciente(cpf) {
    $.ajax({
        url: '/Covid/GetInformacoesPaciente?cpf=' + cpf,
        type: 'GET',
        contentType: 'application/json;',
        success: function (valid) {
            if (valid) {
                //show that id is valid 
            } else {
                //show that id is not valid 
            }
        }
    });
}