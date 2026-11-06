async function cargarDocumetos() {

    const cmbDocumentos = document.getElementById("cmbDocumentos");
    try {
        const response = await fetch('/catalogos/ObtenerDocumentos');
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
//Catálogo de municipios
async function cargarMunicipios(pMunicipio = null, pLocalidad = null) {
    const cmbMunicipio = document.getElementById("cmbUPPNuevaMunicipio");
    try {
        const response = await fetch('/catalogos/ObtenerMunicipios');
        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }
        const data = await response.json();
        cmbMunicipio.innerHTML = '<option value="000">Seleccione un municipio...</option>';
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.claveMunicipio;
            option.textContent = item.nombreMunicipio;
            cmbMunicipio.appendChild(option);
        });
        if (pMunicipio && pMunicipio !== '000') {
            cmbMunicipio.value = pMunicipio;
            //cargarLocalidades(pMunicipio, pLocalidad);
        }
    }
    catch (error) {
        console.error("Error al cargar la lista de municipios:", error);
    }
}

document.getElementById('cmbUPPNuevaMunicipio')?.addEventListener('change', function (e) {
    e.preventDefault();
    const valor = e.target.value;
    cargarLocalidades(valor);
});

async function cargarLocalidades(pMunicipio, pLocalidad = null) {
    const cmbLocalidad = document.getElementById("cmbUPPNuevaLocalidad");
    try {
        const response = await fetch(`/catalogos/ObtenerLocalidades/${pMunicipio}`);
        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }
        const data = await response.json();
        cmbLocalidad.innerHTML = '<option value="0000" disabled selected>Seleccione una localidad... </option>';
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.claveLocalidad;
            option.textContent = item.nombreLocalidad;
            cmbLocalidad.appendChild(option);
        });

        if (pLocalidad && pLocalidad !== '0000') {
            cmbLocalidad.value = pLocalidad;
        }

    }
    catch (error) {
        console.error("Error al cargar la lista de localidades:", error);
    }
}
