let modalElemento = null;
let uppEnviada = "";

document.addEventListener('DOMContentLoaded', function () {

    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));

    let uppOrigenEcontrada = false;
    let uppDestinoEcontrada = false;

    let tipoClaveOrigen = "";
    let raizClaveOrigen = ""
    let tipoClaveDestino = "";
    let raizClaveDestino = "";

    modalElemento = document.getElementById('modalBuscarUPP');
    modalElemento.addEventListener('hidden.bs.modal', function (event) {
        if (uppEnviada == "O") {
            document.getElementById("txtUPPOrigen").value = document.getElementById('txtBuscarUPP').value;
        } else {
            document.getElementById("txtUPPDestino").value = document.getElementById('txtBuscarUPP').value;
        }
        buscarUpp(uppEnviada);
    });

});

document.getElementById('formSolicitud').addEventListener('submit', function (event) {

    event.preventDefault();

    const divErrores = document.getElementById('divErrores');
    divErrores.classList.add('d-none');

    const contenedorErrores = document.getElementById('listaErrores');
    contenedorErrores.innerHTML = ''; // Limpiar errores anteriores
    var erroresEncontrados = false;

    //Validando campos obligatorios
    const camposRequeridos = document.querySelectorAll('input[required], select[required]');
    camposRequeridos.forEach(campo => {
        campo.classList.remove('is-invalid');
        if (!campo.value.trim()) {
            campo.classList.add('is-invalid');
            let feedback = campo.nextElementSibling;
            if (!feedback || !feedback.classList.contains('invalid-feedback')) {
                feedback = document.createElement('div');
                feedback.className = 'invalid-feedback';
                feedback.textContent = '* Este campo es obligatorio.';
                campo.parentNode.appendChild(feedback);
            }
            erroresEncontrados = true;
        }
    });

    const regexEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const regexCelular = /^\d+$/;
    const correo = document.getElementById('correoElectronico').value;
    const celular = document.getElementById('numeroCelular').value;

    const numeroHembras = parseInt(document.getElementById('hembras').value);
    const numeroMachos = parseInt(document.getElementById('machos').value);
    const tipoGanado = document.querySelector('#tipoGanado')?.value;

    if (!correo && !celular) {
        contenedorErrores.innerHTML += '<li>Se debe de proporcionar al menos un dato de contacto (correo electrónico y/o número de celular).</li>';
        erroresEncontrados = true
    } else {
        if (correo) {
            if (!regexEmail.test(correo)) {
                contenedorErrores.innerHTML += '<li>Error: La cadena capturada no corresponde a una cuenta de correo electrónico válida.</li>';
                erroresEncontrados = true
            }
        }
        if (celular) {
            if (!regexCelular.test(celular)) {
                contenedorErrores.innerHTML += '<li>Error: La cadena caprurada no corresponde al formato para el número celular.</li>';
                erroresEncontrados = true
            }
        }
    }

    if (tipoGanado == 0) {
        contenedorErrores.innerHTML += '<li>Error: Se debe de seleccionar el tipo de ganado que se va a movilizar.</li>';
        erroresEncontrados = true
    }

    if (numeroHembras < 0) {
        contenedorErrores.innerHTML += '<li>Error: La cantidad de hembras no puede ser menor que cero.</li>';
        erroresEncontrados = true
    }
    if (numeroMachos < 0) {
        contenedorErrores.innerHTML += '<li>Error: La cantidad de machos no puede ser menor que cero.</li>';
        erroresEncontrados = true
    }
    if ((numeroHembras + numeroMachos) <= 0) {
        contenedorErrores.innerHTML += '<li>Error: La suma de machos y/o hembras debe de ser mayor a cero.</li>';
        erroresEncontrados = true
    }

    if (erroresEncontrados) {
        if (contenedorErrores.innerHTML.length > 0) {
            divErrores.classList.remove('d-none');
        }
        return; // Evita el envío del formulario
    }

    this.submit();

});

async function cargarDocumetos() {
    
    const cmbDocumentos = document.getElementById("cmbDocumentos");
    try {
        const response = await fetch('/solicitudInternacion/ObtenerDocumentos');
        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }
        const data = await response.json();
        cmbDocumentos.innerHTML = '<option value="0">Seleccione un documento... </option>';
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idDocumento;
            option.textContent = item.descDocumento;
            cmbDocumentos.appendChild(option);
        });

    }
    catch (error) {
        console.error("Error al cargar la lista de documentos:", error);
    }

}

async function buscarUpp(desde) {

    //const modalElemento = document.getElementById('modalBuscarUPP');
    const modalInstance = bootstrap.Modal.getOrCreateInstance(modalElemento);
    const uppOrigen = document.getElementById("txtBuscarUPP");
    uppEnviada = desde;

    if (desde == 'O') {
        uppOrigen.value = document.getElementById("txtUPPOrigen").value;
    } else {
        uppOrigen.value = document.getElementById("txtUPPDestino").value;
    }

    if (uppOrigen.value.length > 0) {

        const url = `/solicitudInternacion/buscarUPP/${uppOrigen.value}`;
        try {
            const response = await fetch(url);
            if (!response.ok) {
                //UPP/PSG no encontrada en el catálogo
                modalInstance.show();
                if (desde == 'O') {
                    document.getElementById("alertaOrigen").classList.add("d-none")
                    document.getElementById("alertaOrigen").innerHTML = ""
                } else {
                    document.getElementById("alertaDestino").classList.add("d-none")
                    document.getElementById("alertaDestino").innerHTML = ""
                }
            } else {
                //UPP/PSG encontrada en el catálogo
                const data = await response.json();
                if (desde == 'O') {
                    document.getElementById("datosOrigen").classList.remove("d-none")
                    document.getElementById("txtNombreRemitente").innerHTML = `<strong>Remitente:</strong> ${data.nombreProductor}`;
                    document.getElementById("txtPredioRemitente").innerHTML = `<strong>Nombre del predio:</strong> ${data.nombrePredio}`;
                    document.getElementById("txtUbicacionRemitente").innerHTML = `<strong>Ubicación:</strong> ${data.ubicacion}`;
                    document.getElementById("txtMunicipioRemitente").innerHTML = `<strong>Municipio:</strong> ${data.nombreMunicipio}`;
                    document.getElementById("txtEstadoRemitente").innerHTML = `<strong>Estado:</strong> ${data.nombreEstado}`;
                    document.getElementById("txtZonaRemitente").innerHTML = `<strong>Región:</strong> ZONA ${data.tipoZona}`;
                    document.getElementById("txtStatusRemitente").innerHTML = `<strong>Estatus:</strong> ${data.tipoEstatus}`;
                    document.getElementById("alertaOrigen").classList.remove("d-none");
                    document.getElementById("alertaOrigen").innerHTML = "Datos del origen registrado correctamente.";
                    uppOrigenEcontrada = true;
                } else {
                    document.getElementById("datosDestino").classList.remove("d-none")
                    document.getElementById("txtNombreDestino").innerHTML = `<strong>Remitente:</strong> ${data.nombreProductor}`;
                    document.getElementById("txtPredioDestino").innerHTML = `<strong>Nombre del predio:</strong> ${data.nombrePredio}`;
                    document.getElementById("txtUbicacionDestino").innerHTML = `<strong>Ubicación:</strong> ${data.ubicacion}`;
                    document.getElementById("txtMunicipioDestino").innerHTML = `<strong>Municipio:</strong> ${data.nombreMunicipio}`;
                    document.getElementById("txtEstadoDestino").innerHTML = `<strong>Estado:</strong> ${data.nombreEstado}`;
                    document.getElementById("txtZonaDestino").innerHTML = `<strong>Región:</strong> ZONA ${data.tipoZona}`;
                    document.getElementById("txtStatusDestino").innerHTML = `<strong>Estatus:</strong> ${data.tipoEstatus}`;
                    document.getElementById("alertaDestino").classList.remove("d-none");
                    document.getElementById("alertaDestino").innerHTML = "Datos del destino registrado correctamente.";
                    uppDestinoEcontrada = true;
                }
                if (uppOrigenEcontrada && uppDestinoEcontrada) {
                    document.getElementById("btnGuardar").classList.remove("disabled");
                    //Obtiene el valor de las claves
                    const claveOrigen = document.getElementById("txtUPPOrigen").value;
                    const claveDestino = document.getElementById("txtUPPDestino").value;
                    //Determina si se trata de una UPP o de una PSG
                    if (!claveOrigen.includes("P")) { tipoClaveOrigen = "UPP"; } else { tipoClaveOrigen = "PSG"; raizClaveOrigen = claveOrigen.substr(-3); }
                    if (!claveDestino.includes("P")) { tipoClaveDestino = "UPP"; } else { tipoClaveDestino = "PSG"; raizClaveDestino = claveDestino.substr(-3); }
                    document.getElementById("continuarTramite").classList.remove("d-none");
                    if (tipoClaveOrigen == "UPP" && tipoClaveDestino == "UPP") {
                        document.getElementById("tipoMovilizacion").value = "REPRODUCCIÓN PIE DE CRÍA"
                        document.getElementById("motivoTraslado").value = "1";
                    }
                } else {
                    document.getElementById("continuarTramite").classList.add("d-none");
                }
            }
        }
        catch (error) {
            console.error("Error al buscar la UPP/PSG:", error);
        }

    }

}

document.getElementById('txtUPPOrigen').addEventListener('input', function () {
    uppOrigenEcontrada = false;
    document.getElementById('txtNombreRemitente').innerHTML = '';
    document.getElementById('txtPredioRemitente').innerHTML = '';
    document.getElementById('txtUbicacionRemitente').innerHTML = '';
    document.getElementById('txtMunicipioRemitente').innerHTML = '';
    document.getElementById('txtEstadoRemitente').innerHTML = '';
    document.getElementById('txtZonaRemitente').innerHTML = '';
    document.getElementById('txtStatusRemitente').innerHTML = '';
    document.getElementById('alertaOrigen').innerHTML = '';
    document.getElementById('datosOrigen').classList.add('d-none');
    document.getElementById('alertaOrigen').classList.add('d-none');
    document.getElementById("btnGuardar").classList.add("disabled");
});

document.getElementById('txtUPPDestino').addEventListener('input', function () {
    uppDestinoEcontrada = false;
    document.getElementById('txtNombreDestino').innerHTML = '';
    document.getElementById('txtPredioDestino').innerHTML = '';
    document.getElementById('txtUbicacionDestino').innerHTML = '';
    document.getElementById('txtMunicipioDestino').innerHTML = '';
    document.getElementById('txtEstadoDestino').innerHTML = '';
    document.getElementById('txtZonaDestino').innerHTML = '';
    document.getElementById('txtStatusDestino').innerHTML = '';
    document.getElementById('alertaDestino').innerHTML = '';
    document.getElementById('datosDestino').classList.add('d-none');
    document.getElementById('alertaDestino').classList.add('d-none');
    document.getElementById("btnGuardar").classList.add("disabled");
});

