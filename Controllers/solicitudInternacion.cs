using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
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
        private readonly ISolicitudInternacion _solicitudInternacionService;
        private readonly IUpp _UppServices;
        private readonly ISolicitudInternacionDocumentos _solicitudInternacionDocumentosService;

        public solicitudInternacionController(
            SedarpaContext context, 
            IProductorUPPServices productorUppService, 
            ISolicitudInternacion solicitudInternacionService,
            IUpp UppServices,
            ISolicitudInternacionDocumentos solicitudInternacionDocumentosService)
        {
            _context = context;
            _productorUppService = productorUppService;
            _solicitudInternacionService = solicitudInternacionService;
            _UppServices = UppServices;
            _solicitudInternacionDocumentosService = solicitudInternacionDocumentosService;
        }

        /*** Método para la carga inicial de la solicitud y apertura del registro ****/
        public ActionResult Index()
        {

            var registro = new solicitudInternacionDto();
            registro.FechaCaptura = DateTime.Now;
            registro.StatusSolicitud = 1;
            registro.FechaRecepcion = DateTime.Now;

            return View(registro);

        }

        /*** método para obtener los datos de la UPP/PSG ****/
        [HttpGet]
        public async Task<IActionResult> buscarUPP(string id)
        {

            try
            {
                var Upp = await _UppServices.ObtenerUppPorClaveAsync(id);
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

        /*** Método que llama al servicio para guardar la solicitud del permiso de internación y redirige a la carga de los documentos ***/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] solicitudInternacionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            
            try
            {
                int nuevaSolicitud = await _solicitudInternacionService.GuardarSolicitudInternacionAsync(dto);
                return RedirectToAction("solicitudInternacionDocumentos", new { id = nuevaSolicitud });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pudo guardar la solicitud. Intente nuevamente. Error: " + ex.Message);
                return View(dto);
            }
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
            try
            {
                bool guardadoExitoso = await _solicitudInternacionService.SubirDocumentoAsync(archivo, idDocumento, idSolicitud, observaciones);
                if (!guardadoExitoso)
                {
                    return BadRequest(new { mensaje = "No se pudo procesar el archivo." });
                }
                return Ok(new { mensaje = "Documento guardado exitosamente." });

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
                var documentosCargados = await _solicitudInternacionDocumentosService.ObtenerDocumentosPorSolicitudAsync(idSolicitud);
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

            var registroSolicitud = await _solicitudInternacionService.ObtenerSolicitudInternacionAsync(id);
            if (registroSolicitud == null)
            {
                return NotFound($"No se encontró la solicitud con ID {id}");
            }

            var registroProductorOrigen = await _UppServices.LeerRegistroUPP(registroSolicitud.Origen!);
            var registroProductorDestino = await _UppServices.LeerRegistroUPP(registroSolicitud.Destino!);

            if (registroProductorOrigen == null || registroProductorDestino == null)
            {
                return NotFound("No se encontró la información de la UPP de Origen o Destino asociada a la solicitud.");
            }

            var solicitudModel = new datosSolicitud
            {
                solicitud = registroSolicitud,
                productor = registroProductorOrigen,
                productorDestino = registroProductorDestino
            };

            return View(solicitudModel);

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

        [HttpGet]
        public async Task<IActionResult> validarCURP(string id)
        {
            var productor = await _solicitudInternacionService.ValidarCURPAsync(id);
            if (productor != null)
            {
                return Ok(new { exists = true, data = productor });
            }
            return Ok(new { exists = false });
        }

    }
}

