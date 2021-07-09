var testeCont = document.getElementById("container-info-paciente-inserir-vacinado");

$('#teste-button').on("click", function () {

    if (testeCont.style.display === "none") {
        testeCont.style.display = "block";
    } else {
        testeCont.style.display = "none";
    }
});