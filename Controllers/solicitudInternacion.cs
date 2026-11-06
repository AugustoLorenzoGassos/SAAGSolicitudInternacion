using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using solicitudInternacion.Models;
using solicitudInternacion.Models.DTOs;
using solicitudInternacion.Services;
using solicitudInternacion.ViewModels;
using System.IO;
using System.Threading.Tasks;

namespace solicitudInternacion.Controllers
{
    public class solicitudInternacionController : Controller
    {
        private readonly SedarpaContext _context;
        private readonly IProductorUPPServices _productorUppService;

        public solicitudInternacionController(SedarpaContext context, IProductorUPPServices productorUppService)
        {
            _context = context;
            _productorUppService = productorUppService;
        }

        /*** Método para ola carga inicial de la solicitud y apertura del registro ****/
        public ActionResult Index()
        {

            var registro = new SolicitudInternacion();
            registro.FechaCaptura = DateTime.Now;
            registro.StatusSolicitud = 1;
            registro.FechaRecepcion = DateTime.Now;

            return View(registro);

        }

        /*** Método para guardar la solicitud y redirigir a la carga de documentos ****/
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

        /*** Método para la carga de la vista de documentos ****/
        public ActionResult solicitudInternacionDocumentos(int id)
        {
            var solicitud = _context.SolicitudInternacions.Find(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        /*** Método para la carga de documentos ****/
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

                string tipoMime = archivo.ContentType;

                //Generar el registro en la base de datos
                var documento = new SolicitudInternacionDocumento()
                {
                    IdDocumento = idDocumento,
                    IdSolicitudInternacion = idSolicitud,
                    NombreDocumento = nombreArchivo,
                    Observaciones = observaciones,
                    FechaCarga = DateTime.Now,
                    TipoMime = tipoMime
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

        /**** método para obtener los documentos cargados de la solicitud ****/
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

        /*** método para cerrar la solicitud y redirigir a la página de cierre ****/
        public async Task<ActionResult> solicitudInternacionCerrarTramite(int id)
        {

            /*var solicitud = await _context.SolicitudInternacions
                .Where (s => s.IdSolicitudInternacion == id)
                .FirstOrDefaultAsync();*/

            var registroSolicitud = await _context.SolicitudInternacions.FirstOrDefaultAsync(s => s.IdSolicitudInternacion == id);

            var registroProductor = await _context.CatalogoProductoresUpps
                                        .Where(upp => upp.ClaveUpp == registroSolicitud.Origen)
                                        .Include(p => p.IdProductorNavigation)
                                        .Include(l => l.CatalogoLocalidade)
                                            .ThenInclude(m => m.ClaveMunicipioNavigation)
                                        .FirstOrDefaultAsync();

            var registroProductorDestino = await _context.CatalogoProductoresUpps
                                            .Where(upp => upp.ClaveUpp == registroSolicitud.Destino)
                                            .Include(p => p.IdProductorNavigation)
                                            .Include(l => l.CatalogoLocalidade)
                                                .ThenInclude(m => m.ClaveMunicipioNavigation)
                                            .FirstOrDefaultAsync();

            var solicitudModel = new datosSolicitud
            {
                solicitud = registroSolicitud,
                productor = registroProductor,
                productorDestino = registroProductorDestino
            };

            return View(solicitudModel);
        }

        /*** método para obtener los datos de la UPP/PSG ****/
        [HttpGet]
        public async Task<IActionResult> buscarUPP(string id) {

            try
            {

                var Upp = await _context.CatalogoProductoresUpps
                    .Select(upp => new
                    {
                        upp.ClaveUpp,
                        nombreProductor = upp.IdProductorNavigation.NombreProductor + " " + upp.IdProductorNavigation.ApellidoPaternoProductor + " " + upp.IdProductorNavigation.ApellidoMaternoProductor,
                        nombrePredio = upp.NombreUpp.ToUpper(),
                        ubicacion = upp.Ubicacion != null ? upp.Ubicacion.ToUpper() : "Sin dato",
                        nombreMunicipio = upp.CatalogoLocalidade.ClaveMunicipioNavigation.NombreMunicipio.ToUpper(),
                        nombreLocalidad = upp.CatalogoLocalidade.NombreLocalidad,
                        nombreEstado = _context.CatalogoEntidadesFederativas
                            .Where(e => e.ClaveEstado == upp.ClaveUpp.Substring(0, 2))
                            .Select(e => e.NombreEstado.ToUpper())
                            .FirstOrDefault(),
                        upp.CatalogoLocalidade.ClaveMunicipioNavigation.TipoZona,
                        tipoEstatus = "SIN DATO"
                    })
                    .Where(c => c.ClaveUpp == id)
                    .FirstOrDefaultAsync();
                if (Upp == null)
                {
                    return NotFound(new { mensaje = "No se encontró la UPP/PSG (" + id + ")" });
                }
                return Json(Upp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener laboratorios", detalle = ex.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> GuardarProductorUPP([FromBody] productorUppDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Datos no válidos." });
            }

            try
            {
                bool resultado = await _productorUppService.GuardarProductorConUppAsync(dto);

                if (resultado)
                {
                    return Json(new { success = true, message = "Productor y UPP guardados correctamente." });
                }

                return BadRequest(new { success = false, message = "No se pudo registrar la información." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error interno.", error = ex.Message });
            }
        }

        /*** método para mostrar al usuario el status de su solicitud ****/
        public async Task<IActionResult> solicitudInternacionSeguimiento(int id) {
            return View();
        }
    }
}

