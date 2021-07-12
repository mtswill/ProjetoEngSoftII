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

$('#cpf-vacinado').on("keyup", function () {
    var cpf = document.getElementById("cpf-vacinado").value;

    if (cpf.length > 2) {
        window.alert("teste");
    }
});