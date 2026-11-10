using solicitudInternacion.Models;
using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.Services
{
    public interface ISolicitudInternacion
    {
        Task<solicitudInternacionDto?> ObtenerSolicitudInternacionAsync(int id);
        Task<int> GuardarSolicitudInternacionAsync(solicitudInternacionDto dto);
        Task<CatalogoProductore?> ValidarCURPAsync(string idCURP);
        Task<bool> SubirDocumentoAsync(IFormFile archivo, int idDocumento, int idSolicitud, string observaciones);
    }
}
