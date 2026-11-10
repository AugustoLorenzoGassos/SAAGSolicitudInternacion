using System.Diagnostics.Contracts;

namespace solicitudInternacion.Models.DTOs
{
    public class solicitudInternacionDocumentosListaDTO
    {
        public int? IdDocumento { get; set; }
        public string? NombreDocumento { get; set; }
        public string? Observaciones { get; set; }
        public string? tipoDocumento { get; set; }
        public DateTime? FechaCarga { get; set; }
    }
}
