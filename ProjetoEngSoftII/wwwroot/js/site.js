var testeCont = document.getElementById("teste-container");

$('#teste-button').on("click", function () {
    //testeCont.style.backgroundColor = "green";

    if (testeCont.style.backgroundColor === "green") {
        window.alert("mudou");
        testeCont.style.backgroundColor = "red";
    }
    else {
        testeCont.style.backgroundColor = "red";
    }
});