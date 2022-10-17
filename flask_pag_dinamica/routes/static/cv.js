document.addEventListener('DOMContentLoaded', () => {
    
    document.querySelector('#mas-experiencia').onclick = () => {

        if(document.querySelector('#add-experience')!=null){
            return;
        }
        const myDiv = document.createElement("div");

        const experienceForm = document.createElement('form');
        experienceForm.setAttribute('id','add-experience');
        experienceForm.setAttribute('method','POST');
        myDiv.appendChild(experienceForm);

        const input1 = document.createElement('input');
        input1.setAttribute('id','cargo');
        input1.setAttribute('autocomplete','off');
        input1.setAttribute('placeholder','Cargo');
        input1.setAttribute('type','text');
        input1.classList.add("experience-input");
        experienceForm.appendChild(input1);

        const input2 = document.createElement('input');
        input2.setAttribute('id','lugar');
        input2.setAttribute('autocomplete','off');
        input2.setAttribute('placeholder','Lugar');
        input2.setAttribute('type','text');
        input2.classList.add("experience-input");
        experienceForm.appendChild(input2);

        const input3 = document.createElement('input');
        input3.setAttribute('id','periodo');
        input3.setAttribute('autocomplete','off');
        input3.setAttribute('placeholder','Periodo');
        input3.setAttribute('type','text');
        input3.classList.add("experience-input");
        experienceForm.appendChild(input3);

        const submitButton = document.createElement('button');
        submitButton.setAttribute('id','submit');
        submitButton.innerHTML +='Enviar';
        submitButton.disabled = true;
        myDiv.appendChild(submitButton);
        
        document.querySelector('#experiencia').appendChild(myDiv);

        inputList = document.querySelectorAll('.experience-input');
        inputList.forEach(input => {
            input.onchange = () => {
                disabledSubmit = false;
                for(var i=0; i<inputList.length; i++){
                    if(inputList[i].value.length == 0){
                        disabledSubmit = true;
                    }
                }
                submitButton.disabled = disabledSubmit;
            }
        });
        
        submitButton.onclick = () => {
            const experienceInstance = document.createElement("div");
            experienceInstance.classList.add("medsmall");
    
            const cargo = document.createElement('b');
            cargo.innerHTML = document.querySelector('#cargo').value;
            experienceInstance.appendChild(cargo);
            experienceInstance.appendChild(document.createElement('br'));
    
            const lugar = document.createElement('b');
            const lugartitulo = document.createElement('i');
            lugartitulo.innerHTML = document.querySelector('#lugar').value;
            lugar.appendChild(lugartitulo);
            experienceInstance.appendChild(lugar);
            experienceInstance.innerHTML += " | "+document.querySelector('#periodo').value;
    
            document.querySelector('#experiencia').appendChild(experienceInstance);
    
            myDiv.remove();
        };
    };
    document.querySelector('#mas-formacion').onclick = () => {

        if(document.querySelector('#add-formacion')!=null){
            return;
        }
        const myDiv = document.createElement("div");

        const experienceForm = document.createElement('form');
        experienceForm.setAttribute('id','add-formacion');
        experienceForm.setAttribute('method','POST');
        myDiv.appendChild(experienceForm);

        const input1 = document.createElement('input');
        input1.setAttribute('id','grado');
        input1.setAttribute('autocomplete','off');
        input1.setAttribute('placeholder','Grado');
        input1.setAttribute('type','text');
        input1.classList.add("formation-input");
        experienceForm.appendChild(input1);

        const input2 = document.createElement('input');
        input2.setAttribute('id','lugar');
        input2.setAttribute('autocomplete','off');
        input2.setAttribute('placeholder','Lugar');
        input2.setAttribute('type','text');
        input2.classList.add("formation-input");
        experienceForm.appendChild(input2);

        const input3 = document.createElement('input');
        input3.setAttribute('id','periodo');
        input3.setAttribute('autocomplete','off');
        input3.setAttribute('placeholder','Periodo');
        input3.setAttribute('type','text');
        input3.classList.add("formation-input");
        experienceForm.appendChild(input3);

        const submitButton = document.createElement('button');
        submitButton.setAttribute('id','submit');
        submitButton.innerHTML +='Enviar';
        submitButton.disabled = true;
        myDiv.appendChild(submitButton);

        document.querySelector('#formacion').appendChild(myDiv);
        
        inputList = document.querySelectorAll('.formation-input');
        inputList.forEach(input => {
            input.onchange = () => {
                disabledSubmit = false;
                for(var i=0; i<inputList.length; i++){
                    if(inputList[i].value.length == 0){
                        disabledSubmit = true;
                    }
                }
                submitButton.disabled = disabledSubmit;
            }
        });
        
        submitButton.onclick = () => {
            const experienceInstance = document.createElement("div");
            experienceInstance.classList.add("medsmall");
    
            const cargo = document.createElement('b');
            cargo.innerHTML = document.querySelector('#grado').value;
            experienceInstance.appendChild(cargo);
            experienceInstance.appendChild(document.createElement('br'));
    
            const lugar = document.createElement('b');
            const lugartitulo = document.createElement('i');
            lugartitulo.innerHTML = document.querySelector('#lugar').value;
            lugar.appendChild(lugartitulo);
            experienceInstance.appendChild(lugar);
            experienceInstance.innerHTML += " | "+document.querySelector('#periodo').value;
    
            document.querySelector('#formacion').appendChild(experienceInstance);
    
            myDiv.remove();
        };
    };
    document.querySelector('#mas-idiomas').onclick = () => {
        if(document.querySelector('#add-idioma')!=null){
            return;
        }
        const myDiv = document.createElement("div");

        const experienceForm = document.createElement('form');
        experienceForm.setAttribute('id','add-idioma');
        experienceForm.setAttribute('method','POST');
        myDiv.appendChild(experienceForm);

        const input1 = document.createElement('input');
        input1.setAttribute('id','idioma');
        input1.setAttribute('autocomplete','off');
        input1.setAttribute('placeholder','Idioma');
        input1.setAttribute('type','text');
        experienceForm.appendChild(input1);

        const input2 = document.createElement('input');
        input2.setAttribute('id','nivel');
        input2.setAttribute('autocomplete','off');
        input2.setAttribute('placeholder','Nivel');
        input2.setAttribute('type','text');
        experienceForm.appendChild(input2);

        const submitButton = document.createElement('button');
        submitButton.innerHTML +='Enviar';
        myDiv.appendChild(submitButton);
        
        document.querySelector('#idiomas').appendChild(myDiv);
        
        submitButton.onclick = () => {
            const maindiv = document.createElement("div");
            maindiv.innerHTML+=document.querySelector('#idioma').value+": "+document.querySelector('#nivel').value+"<br>";
            document.querySelector('#idiomas').appendChild(maindiv);
            myDiv.remove();
        };
    };
    document.querySelector('#mas-aptitudes').onclick = () => {
        if(document.querySelector('#add-aptitudes')!=null){
            return;
        }
        const myDiv = document.createElement("div");

        const experienceForm = document.createElement('form');
        experienceForm.setAttribute('id','add-aptitudes');
        experienceForm.setAttribute('method','POST');
        myDiv.appendChild(experienceForm);

        const input1 = document.createElement('input');
        input1.setAttribute('id','nuevaAptitud');
        input1.setAttribute('autocomplete','off');
        input1.setAttribute('placeholder','Nueva aptitud');
        input1.setAttribute('type','text');
        experienceForm.appendChild(input1);

        const submitButton = document.createElement('button');
        submitButton.innerHTML +='Enviar';
        submitButton.disabled = true;
        myDiv.appendChild(submitButton);

        input1.onchange = () => {
            if(input1.value == ""){
                submitButton.disabled = true;
            }
            else{
                submitButton.disabled = false;
            }
        };
        
        document.querySelector('#aptitudes').appendChild(myDiv);
        
        submitButton.onclick = () => {
            const maindiv = document.createElement("div");
            maindiv.innerHTML+="·  "+document.querySelector('#nuevaAptitud').value;
            document.querySelector('#aptitudes').appendChild(maindiv);
            myDiv.remove();
        };
    };
    document.querySelector('#mas-habilidades').onclick = () => {
        if(document.querySelector('#add-habilidades')!=null){
            return;
        }
        const myDiv = document.createElement("div");

        const experienceForm = document.createElement('form');
        experienceForm.setAttribute('id','add-habilidades');
        experienceForm.setAttribute('method','POST');
        myDiv.appendChild(experienceForm);

        const input1 = document.createElement('input');
        input1.setAttribute('id','nuevaHabilidad');
        input1.setAttribute('autocomplete','off');
        input1.setAttribute('placeholder','Nueva habilidad');
        input1.setAttribute('type','text');
        experienceForm.appendChild(input1);

        const submitButton = document.createElement('button');
        submitButton.innerHTML +='Enviar';
        submitButton.disabled = true;
        myDiv.appendChild(submitButton);
        
        input1.onchange= ()=>{
            if(input1.value == ""){
                submitButton.disabled = true;
            }
            else{
                submitButton.disabled = false
            }
        };

        document.querySelector('#habilidades').appendChild(myDiv);
        
        submitButton.onclick = () => {
            const maindiv = document.createElement("div");
            maindiv.innerHTML+="·  "+document.querySelector('#nuevaHabilidad').value;
            document.querySelector('#habilidades').appendChild(maindiv);
            myDiv.remove();
        };
    };
});