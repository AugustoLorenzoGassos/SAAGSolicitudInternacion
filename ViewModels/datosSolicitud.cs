using solicitudInternacion.Models;
using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.ViewModels
{
    public class datosSolicitud
    {
        public solicitudInternacionDto? solicitud {  get; set; }
        public CatalogoProductoresUppDto? productor { get; set; }
        public CatalogoProductoresUppDto? productorDestino { get; set; }

    }
}
