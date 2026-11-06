using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solicitudInternacion.Models;

namespace solicitudInternacion.Controllers
{
    public class catalogosController : Controller
    {
        private readonly SedarpaContext _context;

        public catalogosController(SedarpaContext context)
        {
            _context = context;
        }
        /**** método para obtener los municipios del catálogo ****/
        public async Task<IActionResult> ObtenerMunicipios()
        {
            try
            {
                var municipios = await _context.CatalogoMunicipios
                    .Select(m => new
                    {
                        m.ClaveMunicipio,
                        m.NombreMunicipio
                    })
                    .OrderBy(m => m.NombreMunicipio)
                    .ToListAsync();
                return Json(municipios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener municipios", detalle = ex.Message });
            }
        }
        /**** método para obtener las locaidades del catálogo (con el municipio seleccionado) ****/
        public async Task<IActionResult> ObtenerLocalidades(string id)
        {
            try
            {
                var localidades = await _context.CatalogoLocalidades
                    .Where(m => m.ClaveMunicipio == id)
                    .Select(m => new
                    {
                        m.ClaveMunicipio,
                        m.ClaveLocalidad,
                        m.NombreLocalidad
                    })
                    .OrderBy(m => m.NombreLocalidad)
                    .ToListAsync();
                return Json(localidades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener localidades", detalle = ex.Message });
            }
        }
        /**** método para obtener los documentos del catálogo ****/
        public async Task<IActionResult> ObtenerDocumentos()
        {
            try
            {
                // Se seleccionan solo los campos necesarios para aligerar la respuesta JSON
                var documentos = await _context.CatalogoDocumentos
                    .Select(l => new
                    {
                        l.IdDocumento,
                        l.DescDocumento
                    })
                    .OrderBy(l => l.DescDocumento)
                    .ToListAsync();

                return Json(documentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener documentos", detalle = ex.Message });
            }
        }
        /**** método para obtener los productores del catálogo ****/
        public async Task<IActionResult> ObtenerProductores()
        {
            try
            {
                // Se seleccionan solo los campos necesarios para aligerar la respuesta JSON
                var productores = await _context.CatalogoProductores
                    .Select(p => new
                    {
                        p.IdProductor,
                        p.NombreProductor,
                        p.ApellidoPaternoProductor,
                        p.ApellidoMaternoProductor
                    })
                    .OrderBy(p => p.NombreProductor)
                    .ToListAsync();

                return Json(productores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener productores", detalle = ex.Message });
            }
        }

    }
}
