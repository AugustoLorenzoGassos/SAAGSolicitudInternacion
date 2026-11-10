using Microsoft.EntityFrameworkCore;
using solicitudInternacion.Models;
using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.Services
{
    public class UppServices : IUpp
    {
        private readonly SedarpaContext _context;

        public UppServices(SedarpaContext context) {
            _context = context;
        }

        public async Task<CatalogoProductoresUppDto?>LeerRegistroUPP(string claveUpp) {
            return await _context.CatalogoProductoresUpps
                .Where(u => u.ClaveUpp == claveUpp)
                .Select(u => new CatalogoProductoresUppDto
                {
                    IdProductorUpp = u.IdProductorUpp,
                    IdProductor = u.IdProductor,
                    ClaveUpp = u.ClaveUpp,
                    NombreUpp = u.NombreUpp,
                    CveMunicipio = u.CveMunicipio,
                    CveLocalidad = u.CveLocalidad,
                    Latitud = u.Latitud,
                    Longitud = u.Longitud,
                    Ubicacion = u.Ubicacion,
                    TotalHato = u.TotalHato,
                    TotalProbados = u.TotalProbados,
                    EspecieRegistadaBovino = u.EspecieRegistadaBovino,
                    EspecieRegistadaEquino = u.EspecieRegistadaEquino,
                    EspecieRegistadaOvino = u.EspecieRegistadaOvino,
                    EspecieRegistadaPorcino = u.EspecieRegistadaPorcino,
                    EspecieTrabajadaBovino = u.EspecieTrabajadaBovino,
                    EspecieTrabajadaEquino = u.EspecieTrabajadaEquino,
                    EspecieTrabajadaOvino = u.EspecieTrabajadaOvino,
                    EspecieTrabajadaPorcino = u.EspecieTrabajadaPorcino,
                    FechaCaptura = u.FechaCaptura,
                    FechaActualizacion = u.FechaActualizacion,
                    IdUsuario = u.IdUsuario,
                    NombreProductor = u.IdProductorNavigation != null ? u.IdProductorNavigation.NombreProductor : "",
                    ApellidoPaternoProductor = u.IdProductorNavigation != null ? u.IdProductorNavigation.ApellidoPaternoProductor : "",
                    ApellidoMaternoProductor = u.IdProductorNavigation != null ? u.IdProductorNavigation.ApellidoMaternoProductor : "",
                    NombreMunicipio = u.CatalogoLocalidade != null && u.CatalogoLocalidade.ClaveMunicipioNavigation != null ? u.CatalogoLocalidade.ClaveMunicipioNavigation.NombreMunicipio : "SIN MUNICIPIO",
                    NombreLocalidad = u.CatalogoLocalidade != null ? u.CatalogoLocalidade.NombreLocalidad : "SIN LOCALIDAD"
                })
                .FirstOrDefaultAsync();
        }
        public async Task<UppDTO?> ObtenerUppPorClaveAsync(string claveUpp)
        {
            return await _context.CatalogoProductoresUpps
            .Where(upp => upp.ClaveUpp == claveUpp)
            .Select(upp => new UppDTO
            {
                claveUpp = upp.ClaveUpp,
                nombreProductor = upp.IdProductorNavigation !=  null ? (upp.IdProductorNavigation.NombreProductor + " " +
                                    upp.IdProductorNavigation.ApellidoPaternoProductor + " " +
                                    upp.IdProductorNavigation.ApellidoMaternoProductor).Trim():"SIN PRODUCTOR",
                nombrePredio = upp.NombreUpp != null ? upp.NombreUpp.ToUpper() : "SIN NOMBRE DE UPP",
                ubicacion = upp.Ubicacion != null ? upp.Ubicacion.ToUpper() : "SIN DATO",
                nombreMunicipio = upp.CatalogoLocalidade != null && upp.CatalogoLocalidade.ClaveMunicipioNavigation != null ? upp.CatalogoLocalidade.ClaveMunicipioNavigation.NombreMunicipio.ToUpper() : "SIN MUNICIPIO",
                nombreLocalidad = upp.CatalogoLocalidade != null ? upp.CatalogoLocalidade.NombreLocalidad : "SIN LOCALIDAD",
                nombreEstado = _context.CatalogoEntidadesFederativas
                    .Where(e => e.ClaveEstado == upp.ClaveUpp.Substring(0, 2))
                    .Select(e => e.NombreEstado.ToUpper())
                    .FirstOrDefault()!,
                tipoZona = upp.CatalogoLocalidade != null && upp.CatalogoLocalidade.ClaveMunicipioNavigation != null ? upp.CatalogoLocalidade.ClaveMunicipioNavigation.TipoZona : "SIN ZONA",
                tipoEstatus = "SIN DATO"
            })
            .FirstOrDefaultAsync();
        }
    }
}
