
namespace solicitudInternacion.Models.DTOs
{
    public class solicitudInternacionDocumentosDto
    {
        public int IdSolicitudInternacionDocumento { get; set; }
        public int? IdSolicitudInternacion { get; set; }
        public int? IdDocumento { get; set; }
        public string? NombreDocumento { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaCarga { get; set; }
        public string? TipoMime { get; set; }
        public bool? StatusDocumento { get; set; }
        public string? TipoDocumento { get; set; }
    }
}
