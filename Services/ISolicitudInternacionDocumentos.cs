using System.Diagnostics.CodeAnalysis;
using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.Services
{
    public interface ISolicitudInternacionDocumentos
    {
        Task<bool> GuardarSolicitudInternacionDocumentosAsync(solicitudInternacionDocumentosDto dto);

        Task<List<solicitudInternacionDocumentosListaDTO>> ObtenerDocumentosPorSolicitudAsync(int idSolicitudInternacion);

    }
}
