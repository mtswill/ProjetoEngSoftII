var testeCont = document.getElementById("container-info-paciente-inserir-vacinado");
var txtstart = document.getElementById("txtstart");

$('#teste-button').on("click", function () {

    if (testeCont.style.display === "none") {
        testeCont.style.display = "block";
        txtstart.value = "teste";
    } else {
        testeCont.style.display = "none";
    }
});