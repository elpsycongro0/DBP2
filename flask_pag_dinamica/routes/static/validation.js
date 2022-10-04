document.addEventListener('DOMContentLoaded', () => {
    document.querySelector('#submit').disabled = true;
    document.querySelectorAll('.checked_empty').forEach(input => {
        input.onkeyup = () => {
            allIputs = document.querySelectorAll('.checked_empty');
            disabledSubmit = false;
            for (var i = 0; i < allIputs.length; i++) {
                if(allIputs[i].value.length == 0){
                    disabledSubmit = true;
                }
            }
            document.querySelector('#submit').disabled = disabledSubmit;    
            
        };
        input.onblur = () => {
            input.value = input.value.replace(/\s/g, '')
        }
    });
    
});