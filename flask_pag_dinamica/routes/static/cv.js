document.addEventListener('DOMContentLoaded', () => {
    document.querySelector('#submit').onclick = () => {
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

        document.querySelector('#lugar').value = ""
        document.querySelector('#cargo').value = ""
        document.querySelector('#periodo').value = ""

    };
    
});