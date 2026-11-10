using Microsoft.EntityFrameworkCore;
using solicitudInternacion.Models;
using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.Services
{
    public class SolicitudInternacionDocumentosServices: ISolicitudInternacionDocumentos
    {
        private readonly SedarpaContext _context;
        public SolicitudInternacionDocumentosServices(SedarpaContext context)
        {
            _context = context;
        }
        public async Task<bool> GuardarSolicitudInternacionDocumentosAsync(solicitudInternacionDocumentosDto dto)
        {
            var solicitudInternacionDocumentos = new SolicitudInternacionDocumento
            {
                IdSolicitudInternacionDocumento = dto.IdSolicitudInternacionDocumento,
                IdSolicitudInternacion = dto.IdSolicitudInternacion,
                IdDocumento = dto.IdDocumento,
                NombreDocumento = dto.NombreDocumento,
                Observaciones = dto.Observaciones,
                FechaCarga = dto.FechaCarga,
                TipoMime = dto.TipoMime,
                StatusDocumento = dto.StatusDocumento
            };
            _context.SolicitudInternacionDocumentos.Add(solicitudInternacionDocumentos);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<solicitudInternacionDocumentosListaDTO>> ObtenerDocumentosPorSolicitudAsync(int idSolicitudInternacion)
        {
            var documentosCargados = await _context.SolicitudInternacionDocumentos
                .Where(d => d.IdSolicitudInternacion == idSolicitudInternacion)
                .AsNoTracking()
                .Select(d => new solicitudInternacionDocumentosListaDTO
                {
                    IdDocumento = d.IdDocumento,
                    NombreDocumento = d.NombreDocumento,
                    Observaciones = d.Observaciones,
                    tipoDocumento = d.IdDocumentoNavigation != null ? d.IdDocumentoNavigation.DescDocumento : "DOCUMENTO NO IDENTIFICADO",
                    FechaCarga = d.FechaCarga
                })
                .ToListAsync();
            return (documentosCargados);
        }
    }
}
