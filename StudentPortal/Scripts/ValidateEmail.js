function validateEmail() {
    let email = document.getElementById("Email");
    email = email.value;
    let domain = email.slice(email.indexOf('@') + 1);
    if (domain != "unthinkable.co") {
        document.getElementById("Role").disabled = true;
    }
    else if (email=="") {
        document.getElementById("Role").disabled = false;
    }
    else {
        document.getElementById("Role").disabled = false;
    }

    if (document.getElementById("Role").disabled) {
        if (email == "") {
            document.getElementById("Role").disabled = false;
        }
    }

}
