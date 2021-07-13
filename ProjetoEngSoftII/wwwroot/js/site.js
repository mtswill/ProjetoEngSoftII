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
    var container = document.getElementById("container-inserir-vacinado");

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
        if (container.style.display === "none") {
            container.style.display = "block";
        }
    }
    else
    {
        container.style.display = "none";
    }
});