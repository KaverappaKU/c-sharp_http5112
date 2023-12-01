// Creating onload when the page loads
window.onload = pageLoad;

// function pageload()
function pageLoad() {

    // creating form handle to define what happens on form submit
    var formHandle = document.forms.add_teacher;
    formHandle.onsubmit = processForm;
    // Defining URL for api call
    var URL = "http://localhost:51037/api/TeacherData/AddTeacher";
    // Creating a XML HTTP request
    var xhr = new XMLHttpRequest();
    // Opening the XHR request
    xhr.open("POST", URL, true);
    // Setting the type of content we want to send
    xhr.setRequestHeader('Content-Type', 'application/json');


    // function processForm to process the form submit
    function processForm(event) {
        // Event to prevent the default settings
        event.preventDefault();

        // Declaring variables required for validation purpose
        var fnameValue = formHandle.TeacherFname;
        var lnameValue = formHandle.TeacherLname;
        var employeeNumber = formHandle.EmployeeNumber;
        var hireDate = formHandle.HireDate;
        var salary = formHandle.Salary;

        // Regex pattern for employee number validation and hiredate validation
        var employeeNumberValidation = /^[A-Za-z][0-9]{3}$/;
        var hiredateValidation = /^(?:19|20)\d\d-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])$/;

        // Adding validation to First name input field to check whether they are empty and not a number
        if (fnameValue.value === "" || !Number.isNaN(Number(fnameValue.value))) {
            fnameValue.style.background = "red";
            fnameValue.focus();
            return false;
        }
        fnameValue.style.background = "white";

        // Adding validation to Last name input field to check whether they are empty and not a number
        if (lnameValue.value === "" || !Number.isNaN(Number(lnameValue.value))) {
            lnameValue.style.background = "red";
            lnameValue.focus();
            return false;
        }
        lnameValue.style.background = "white";

        // Adding validation to Employee Number input field to check whether they are empty
        if (employeeNumber.value === "" || !employeeNumberValidation.test(employeeNumber.value)) {
            employeeNumber.style.background = "red";
            employeeNumber.focus();
            return false;
        }
        employeeNumber.style.background = "white";

        // Adding validation to Hiredate input field to check whether they are empty
        if (hireDate.value === "" || !hiredateValidation.test(hireDate.value)) {
            hireDate.style.background = "red";
            hireDate.focus();
            return false;
        }
        hireDate.style.background = "white";

        // Adding validation to Salary input field to check whether they are empty and not an alphabet
        if (salary.value === "" | Number.isNaN(Number(salary.value))) {
            salary.style.background = "red";
            salary.focus();
            return false;
        }
        salary.style.background = "white";

        // Declaring the data values you want to send
        var newTeacher = {
            "TeacherFname": fnameValue.value,
            "TeacherLname": lnameValue.value,
            "EmployeeNumber": employeeNumber.value,
            "HireDate": hireDate.value,
            "Salary": salary.value
        }


        // Creating the ready function for sending the XHR request to add teacher data
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status == 204) {
                window.location.href = "http://localhost:51037/Teacher/ListTeachers/"
            } else {
                console.log("API request failed")
            }
        }
        // Send the json object newTeacher
        xhr.send(JSON.stringify(newTeacher));
    }
}
