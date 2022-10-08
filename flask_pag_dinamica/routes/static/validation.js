document.addEventListener('DOMContentLoaded', () => {
    document.querySelector('#submit').disabled = true;
    
    mainForm = document.forms[0];
    mainFormNames = []
    // fill all names in form
    document.querySelectorAll('.checked_empty').forEach(input => {
        mainFormNames.push(input.name);
    });
    // input validation event listeners
    document.querySelectorAll('.checked_empty').forEach(input => {
        input.onchange = () => {
            disabledSubmit = false;
            for(var i=0; i<mainFormNames.length; i++){
                console.log(mainFormNames[i],":", mainForm[mainFormNames[i]].value);
                if(mainForm[mainFormNames[i]].value.length == 0){
                    disabledSubmit = true;
                }
            }
            document.querySelector('#submit').disabled = disabledSubmit;
        }
    });
    document.querySelectorAll('.text_input').forEach(input => {
        input.onblur = () => {
            input.value = input.value.replace(/\s/g, '')
        }
    });
});