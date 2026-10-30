using solicitudInternacion.Models;

namespace solicitudInternacion.ViewModels
{
    public class datosSolicitud
    {
        public SolicitudInternacion solicitud {  get; set; }
        public CatalogoProductoresUpp productor { get; set; }
        public CatalogoProductoresUpp productorDestino { get; set; }

    }
}
