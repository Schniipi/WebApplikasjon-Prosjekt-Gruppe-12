
//Skal kunne slette ordre, skal etterhvert forsøke å få dette til å fjerne elementer fra databasen
function slettOrder(element) {

    $(element).html("");
}


//ikke mulig enda, men skal etterhvert kunne hente flere navn fra databasen
function seOrdre() {
    var endring = "\n @Model.Navn"

    document.getElementById("theDiv").innerHTML += endring;
}