let modalElemento = null;
let uppEnviada = "";
let cerrandoModalManualmente = false;


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
    modalElemento.addEventListener('hidden.bs.modal',async function (event) {
        if (typeof uppEnviada !== 'undefined' && uppEnviada) {
            await buscarUpp(uppEnviada);
        }
    });

    cargarMunicipios();

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

async function buscarUpp(desde) {

    //1. Limpiar los campos del formulario de alta de UPP/PSG
    document.getElementById('txtCURPProductor').value = '';
    document.getElementById('txtNombreProductor').value = '';
    document.getElementById('txtApellidoPaternoProductor').value = '';
    document.getElementById('txtApellidoMaternoProductor').value = '';
    document.getElementById('txtCorreoProductor').value = '';
    document.getElementById('txtCelularProductor').value = '';
    document.getElementById('txtUPPNueva').value = '';
    document.getElementById('txtUPPNuevaNombre').value = '';
    document.getElementById('txtUPPNuevaLatitud').value = '';
    document.getElementById('txtUPPNuevaLongitud').value = '';
   // 2. Resetear Selects / Combos a su opción por defecto
    const cmbGenero = document.querySelector('#cmbGeneroProductor');
    if (cmbGenero) cmbGenero.selectedIndex = 0;
    const cmbEstado = document.querySelector('#cmbUPPNuevaEstado');
    if (cmbEstado) cmbEstado.selectedIndex = 0;
    const cmbMunicipio = document.querySelector('#cmbUPPNuevaMunicipio');
    if (cmbMunicipio) cmbMunicipio.selectedIndex = 0;
    const cmbLocalidad = document.querySelector('#cmbUPPNuevaLocalidad');
    if (cmbLocalidad) cmbLocalidad.selectedIndex = 0;
    // 3. Volver a ocultar alertas de advertencia o errores (restablecer d-none)
    const advertencia = document.getElementById('alertaAltaUPP'); // pon el ID de tu alerta
    if (advertencia) {
        advertencia.classList.remove('d-none');
    }
    //4. Esconder la sección de datos de UPP/PSG
    const datosAltaUPP = document.getElementById('datosAltaUPP');
    if (datosAltaUPP) {
        datosAltaUPP.classList.add('d-none');
    }
    // 5. Volver a habilitar el botón de guardar en caso de que estuviera deshabilitado
    const btnGuardar = document.getElementById('btnGuardarNuevaUPP');
    if (btnGuardar) {
        btnGuardar.classList.remove('disabled');
    }
    //6. Poner activo el primer tab del modal en caso de que se hubiera cambiado a otro tab
    const navProductor = document.getElementById('productor-tab');
    if (navProductor) {
        navProductor.click();
    }

    const modalElemento = document.getElementById('modalBuscarUPP');
    const modalInstance = bootstrap.Modal.getOrCreateInstance(modalElemento);
    const uppOrigen = document.getElementById("txtUPPNueva");
    const uppBuscar = "";

    uppEnviada = desde;

    if (desde == 'O') {
        uppOrigen.value = document.getElementById("txtUPPOrigen").value;
        //uppBuscar = document.getElementById("txtUPPOrigen").value;
    } else {
        uppOrigen.value = document.getElementById("txtUPPDestino").value;
        //uppBuscar = document.getElementById("txtUPPDestino").value;
    }

    if (uppOrigen.value.length > 0) {

        const url = `/solicitudInternacion/buscarUPP/${uppOrigen.value}`;
        
        try {

            const response = await fetch(url);

            if (!response.ok) {
                //UPP/PSG no encontrada en el catálogo
                if (cerrandoModalManualmente) return;
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
                    document.getElementById("txtPredioRemitente").innerHTML = `<strong>Nombre del predio:</strong> ${data.nombreLocalidad}`;
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
                    document.getElementById("txtPredioDestino").innerHTML = `<strong>Nombre del predio:</strong> ${data.nombreLocalidad}`;
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

function cerrarModalUPP() {

    cerrandoModalManualmente = true; // Activamos el candado

    const modalElemento = document.getElementById('modalBuscarUPP');
    const modalInstance = bootstrap.Modal.getInstance(modalElemento);
    if (modalInstance) {
        modalInstance.hide();
    }

    // Forzar limpieza por si acaso
    modalElemento.classList.remove('show');
    modalElemento.style.display = 'none';
    document.querySelectorAll('.modal-backdrop').forEach(el => el.remove());
    document.body.classList.remove('modal-open');
    document.body.style.overflow = '';

    // Liberamos el candado medio segundo después para permitir búsquedas futuras legítimas
    setTimeout(() => {
        cerrandoModalManualmente = false;
    }, 500);

}

function ocultarSecciones(event) {

    document.getElementById('alertaAltaUPP').classList.add('d-none');
    document.getElementById('datosAltaUPP').classList.remove("d-none");
    document.getElementById('btnGuardarNuevaUPP').classList.remove("d-none");
}

function guardarUPP() {

    let erroresEncontrados = false;

    //Validar obligarorios
    const curpProductor = document.getElementById("txtCURPProductor");
    const nombreProductor = document.getElementById("txtNombreProductor");
    const apellidoPaternoProductor = document.getElementById("txtApellidoPaternoProductor");
    const correoProductor = document.getElementById("txtCorreoProductor");
    const celularProductor = document.getElementById("txtCelularProductor");
    const generoProductor = document.getElementById("cmbGeneroProductor");
    const generoProductorValor = document.querySelector('#cmbGeneroProductor')?.value;

    const estadoUPP = document.getElementById("cmbUPPNuevaEstado");
    const estadoUPPValor = document.querySelector('#cmbUPPNuevaEstado')?.value;
    const municipioUPP = document.getElementById("cmbUPPNuevaMunicipio");
    const municipioUPPValor = document.querySelector('#cmbUPPNuevaMunicipio')?.value;
    const localidadUPP = document.getElementById("cmbUPPNuevaLocalidad");
    const localidadUPPValor = document.querySelector('#cmbUPPNuevaLocalidad')?.value;

    const camposConError = document.querySelectorAll('.is-invalid');
    camposConError.forEach(campo => {
        campo.classList.remove('is-invalid');

        // Buscamos si tiene un feedback de error hermano y lo eliminamos
        let feedback = campo.nextElementSibling;
        if (feedback && feedback.classList.contains('invalid-feedback')) {
            feedback.remove();
        }
    });

    if (!curpProductor.value.trim()) {
        curpProductor.classList.add('is-invalid');
        let feedback = curpProductor.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Este campo es obligatorio.';
            curpProductor.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    if (!nombreProductor.value.trim()) {
        nombreProductor.classList.add('is-invalid');
        let feedback = nombreProductor.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Este campo es obligatorio.';
            nombreProductor.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    if (!apellidoPaternoProductor.value.trim()) {
        apellidoPaternoProductor.classList.add('is-invalid');
        let feedback = apellidoPaternoProductor.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Este campo es obligatorio.';
            apellidoPaternoProductor.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    if (!generoProductorValor) {
        generoProductor.classList.add('is-invalid');
        let feedback = generoProductor.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Este campo es obligatorio.';
            generoProductor.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    if (!correoProductor.value.trim() && !celularProductor.value.trim()) {
        correoProductor.classList.add('is-invalid');
        celularProductor.classList.add('is-invalid');
        let feedback = correoProductor.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Se debe ingresar al menos un correo electrónico o un número de celular.';
            correoProductor.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    if (!correoProductor.value.trim() && !celularProductor.value.trim()) {
        correoProductor.classList.add('is-invalid');
        celularProductor.classList.add('is-invalid');
        let feedback = correoProductor.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Se debe ingresar al menos un correo electrónico o un número de celular.';
            correoProductor.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    if (estadoUPPValor === "00") {
        estadoUPP.classList.add('is-invalid');
        let feedback = estadoUPP.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Este campo es obligatorio.';
            estadoUPP.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    if (municipioUPPValor === "000") {
        municipioUPP.classList.add('is-invalid');
        let feedback = municipioUPP.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Este campo es obligatorio.';
            municipioUPP.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    if (localidadUPPValor === "0000") {
        localidadUPP.classList.add('is-invalid');
        let feedback = localidadUPP.nextElementSibling;
        if (!feedback || !feedback.classList.contains('invalid-feedback')) {
            feedback = document.createElement('div');
            feedback.className = 'invalid-feedback';
            feedback.textContent = '* Este campo es obligatorio.';
            localidadUPP.parentNode.appendChild(feedback);
        }
        erroresEncontrados = true;
    }

    //Valdación de consistgencia de los valores
    const regexCurp = /^[A-Z]{4}\d{6}[HM][A-Z]{2}[B-DF-HJ-NP-TV-Z]{3}[A-Z0-9]{2}$/;
    const regexCelular = /^\d+$/;
    const regexEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (curpProductor.value.trim().length > 0) {
        if (!regexCurp.test(curpProductor.value.trim())) {
            alert("error formato de curp");
            curpProductor.classList.add('is-invalid');
            let feedback = curpProductor.nextElementSibling;
            if (!feedback || !feedback.classList.contains('invalid-feedback')) {
                feedback = document.createElement('div');
                feedback.className = 'invalid-feedback';
                feedback.textContent = '* La CURP no es válida.';
                curpProductor.parentNode.appendChild(feedback);
            }
            erroresEncontrados = true;
        }
    }

    //Validación del número de celular en caso de que se haya capturado un valor
    if ((celularProductor.value.trim().length > 0 && celularProductor.value.trim().length <= 10)) {
        if (!regexCelular.test(celularProductor.value.trim()) || celularProductor.value.trim().length < 10) {
            celularProductor.classList.add('is-invalid');
            let feedback = celularProductor.nextElementSibling;
            if (!feedback || !feedback.classList.contains('invalid-feedback')) {
                feedback = document.createElement('div');
                feedback.className = 'invalid-feedback';
                feedback.textContent = '* El número de celular no es válido.';
                celularProductor.parentNode.appendChild(feedback);
            }
            erroresEncontrados = true;
        }
    }

    if (correoProductor.value.trim().length > 0) {
        if (!regexEmail.test(correoProductor.value.trim())) {
            correoProductor.classList.add('is-invalid');
            let feedback = correoProductor.nextElementSibling;
            if (!feedback || !feedback.classList.contains('invalid-feedback')) {
                feedback = document.createElement('div');
                feedback.className = 'invalid-feedback';
                feedback.textContent = '* El correo electrónico no es válido.';
                correoProductor.parentNode.appendChild(feedback);
            }
            erroresEncontrados = true;
        }
    }

    if (!erroresEncontrados) {
        
        //Guardar la información de productor y de la UPP/PSG en el catálogo
        document.getElementById('btnGuardarNuevaUPP').classList.add('disabled');
        const productorUppDto = {
            nombreProductor: document.getElementById('txtNombreProductor').value,
            apellidoPaternoProductor: document.getElementById('txtApellidoPaternoProductor').value,
            apellidoMaternoProductor: document.getElementById('txtApellidoMaternoProductor').value,
            generoProductor: document.querySelector('#cmbGeneroProductor')?.value,
            correoProductor: document.getElementById('txtCorreoProductor').value,
            telefonoProductor: document.getElementById('txtCelularProductor').value,
            curpProductor: document.getElementById('txtCURPProductor').value,
            claveUpp: document.getElementById('txtUPPNueva').value,
            nombreUpp: document.getElementById('txtUPPNuevaNombre').value,
            cveMunicipio: document.querySelector('#cmbUPPNuevaMunicipio')?.value,
            cveLocalidad: document.querySelector('#cmbUPPNuevaLocalidad')?.value,
            latitud: parseFloat(document.getElementById('txtUPPNuevaLatitud').value) || null,
            longitud: parseFloat(document.getElementById('txtUPPNuevaLongitud').value) || null
        };
        fetch('/solicitudInternacion/GuardarProductorUPP', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                // Descomenta la siguiente línea si manejas tokens CSRF / AntiForgery:
                // 'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            },
            body: JSON.stringify(productorUppDto)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error en la respuesta del servidor');
                }
                return response.json();
            })
            .then(data => {
                if (data.success) {
                    console.log(data.message);
                    alert("La información se guardó correctamente.");
                    cerrarModalUPP();
                    buscarUpp(uppEnviada);
                } else {
                    alert('Atención: ' + data.message);
                }
            })
            .catch(error => {
                console.error('Error al guardar:', error);
                alert('Ocurrió un problema de comunicación al intentar guardar la información.');
            });

        cerrarModalUPP();

    }
    
}

async function validarCURP(curp) {

    if (!curp || curp.trim() === '') return;

    try {

        const response = await fetch(`/solicitudInternacion/validarCURP/${encodeURIComponent(curp)}`);
        const result = await response.json();
        alert(result.exists);
        alert(response.data);
        if (result.exists && result.data) {
            const p = result.data;
            document.getElementById('txtNombreProductor').value = p.nombreProductor || '';
            document.getElementById('txtApellidoPaternoProductor').value = p.apellidoPaternoProductor || '';
            document.getElementById('txtApellidoMaternoProductor').value = p.apellidoMaternoProductor || '';
            document.getElementById('txtCorreoProductor').value = p.correoProductor || '';
            document.getElementById('txtCelularProductor').value = p.telefonoProductor || '';
            const optionGenero = document.querySelector(`#cmbGeneroProductor option[value="${p.generoProductor}"]`);
            if (optionGenero) {
                optionGenero.selected = true;
                document.querySelector('#cmbGeneroProductor').dispatchEvent(new Event('change'));
            }

        } else {
            //Limpiar campos de productor
            document.getElementById('txtNombreProductor').value = '';
            document.getElementById('txtApellidoPaternoProductor').value = '';
            document.getElementById('txtApellidoMaternoProductor').value = '';
            document.getElementById('txtCorreoProductor').value = '';
            document.getElementById('txtCelularProductor').value = '';
            const optionGenero = document.querySelector('#cmbGeneroProductor option[value=""]');
            if (optionGenero) {
                optionGenero.selected = true;
                document.querySelector('#cmbGeneroProductor').dispatchEvent(new Event('change'));
            }
        }

    } catch (error) {
        console.log('Error al validar la CURP:', error);
    }

}