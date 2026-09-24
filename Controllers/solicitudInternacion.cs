using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solicitudInternacion.Models;


namespace solicitudInternacion.Controllers
{
    public class solicitudInternacionController : Controller
    {
        private readonly SedarpaContext _context;

        public solicitudInternacionController(SedarpaContext context)
        {
            _context = context;
        }

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

        public ActionResult Index()
        {

            var registro = new SolicitudInternacion();
            registro.FechaCaptura = DateTime.Now;
            return View(registro);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SolicitudInternacion solicitudInternacion)
        {
            if (ModelState.IsValid)
            {
                _context.SolicitudInternacions.Add(solicitudInternacion);
                _context.SaveChanges();
                return RedirectToAction("solicitudInternacionDocumentos", new { id = solicitudInternacion.IdSolicitudInternacion });
            }
            return View(solicitudInternacion);
        }

        public ActionResult solicitudInternacionDocumentos(int id)
        {
            var solicitud = _context.SolicitudInternacions.Find(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        [HttpPost]
        public async Task<IActionResult> SubirDocumento(IFormFile archivo, int idDocumento, int idSolicitud, string observaciones)
        {
            // 1. Validar que se haya recibido un archivo
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest(new { mensaje = "No se ha seleccionado ningún archivo válido." });
            }

            try
            {
                // 2. Definir la ruta donde se guardará (ejemplo: wwwroot/uploads)
                string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                // Crear la carpeta si no existe
                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }

                // Generar la ruta completa con el nombre original del archivo

                string nombreArchivo = idSolicitud.ToString() + "_" + _context.CatalogoDocumentos.Find(idDocumento)?.DescDocumentoCorto + Path.GetExtension(archivo.FileName);
                string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                // 3. Guardar el archivo en el servidor
                using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                //Generar el registro en la base de datos
                var documento = new SolicitudInternacionDocumento()
                {
                    IdDocumento = idDocumento,
                    IdSolicitudInternacion = idSolicitud,
                    NombreDocumento = nombreArchivo,
                    Observaciones = observaciones,
                    FechaCarga = DateTime.Now
                };
                _context.SolicitudInternacionDocumentos.Add(documento);
                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Documento guardado exitosamente.", ruta = rutaCompleta });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor: " + ex.Message });
            }
        }

        public async Task<IActionResult> SolicitudDocumentosCargados(int idSolicitud)
        {
            try
            {
                var documentosCargados = await _context.SolicitudInternacionDocumentos
                    .Where(d => d.IdSolicitudInternacion == idSolicitud)
                    .Select(d => new
                    {
                        d.IdDocumento,
                        d.NombreDocumento,
                        d.Observaciones,
                        tipoDocumento = d.IdDocumentoNavigation.DescDocumento,
                        d.FechaCarga
                    })
                    .ToListAsync();
                return Json(documentosCargados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener documentos cargados", detalle = ex.Message });
            }
        }

    }
}