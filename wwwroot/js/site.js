async function cargarDocumetos() {
    
    const cmbDocumentos = document.getElementById("cmbDocumentos");
    try {
        const response = await fetch('/solicitudInternacion/ObtenerDocumentos');
        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }
        const data = await response.json();
        cmbDocumentos.innerHTML = '<option value="">Seleccione un documento... </option>';
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
