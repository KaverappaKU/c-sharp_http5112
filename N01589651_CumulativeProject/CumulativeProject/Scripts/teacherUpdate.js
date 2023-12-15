window.onload = pageLoad;

function pageLoad() {

    // creating form handle to define what happens on form submit
    var formHandle = document.forms.update_teacher;
    formHandle.onsubmit = UpdateTeacher;
    console.log(formHandle);
    console.log('I am clicked!');
    function UpdateTeacher(event) {
        // Event to prevent the default settings
         event.preventDefault();
        

        console.log('form submited!');
    }

}