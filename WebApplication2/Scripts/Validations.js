function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName') == "")
        return 'First Name should not be empty.';
    else
        return "";
}

function IsFirstNameValid() {
    if (document.getElementById('TxtFName').value.indexOf("@") != -1)
        return 'First Name should not contain @.';
    else
        return "";
}

function IsLastNameValid() {
    if (document.getElementById('TxtLName').value.length < 15) 
        return 'Last Name should not contain more than 15 characters.';
    else
        return "";
}

function IsSalaryEmpty() {
    if (document.getElementById('TxtSalary').value == "") {
        return 'Salary shold not be empty.';
    }
    else {
        return "";
    }
}

function IsSalaryValid() {
    if (isNaN(document.getElementById('TxtSalary').value)) {
        return 'Enter valid salary';
    }
    else {
        return "";
    }
}

function IsValid() {
    var FirstNameEmptyMessage = IsFirstNameEmpty();
    var FirstNameValidMessage = IsFirstNameValid();
    var LastNameValidMessage = IsLastNameValid();
    var SalaryEmptyMessage = IsSalaryEmpty();
    var SalaryValidMessage = IsSalaryValid();

    var FinalErrorMessage = "Errors:";
    if (FirstNameEmptyMessage != "") {
        FinalErrorMessage += "\n" + FirstNameEmptyMessage;
    }
    if (FirstNameValidMessage != "") {
        FinalErrorMessage += "\n" + FirstNameValidMessage;
    }
    if (LastNameValidMessage != "") {
        FinalErrorMessage += "\n" + LastNameValidMessage;
    }
    if (SalaryEmptyMessage != "") {
        FinalErrorMessage += "\n" + SalaryEmptyMessage;
    }
    if (SalaryValidMessage != "") {
        FinalErrorMessage += "\n" + SalaryValidMessage;
    }

    if (FinalErrorMessage != "Errors:") {
        alert(FinalErrorMessage);
        return false;
    }
    else {
        return true;
    }

}