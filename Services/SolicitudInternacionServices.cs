using Microsoft.EntityFrameworkCore;
using solicitudInternacion.Models;
using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.Services
{
    public class SolicitudInternacionServices : ISolicitudInternacion
    {
        private readonly SedarpaContext _context;
        public SolicitudInternacionServices(SedarpaContext context)
        {
            _context = context;
        }
        public async Task<int> GuardarSolicitudInternacionAsync(solicitudInternacionDto dto)
        {
            var solicitudInternacion = new SolicitudInternacion
            {
                FechaCaptura = dto.FechaCaptura,
                FechaRecepcion = dto.FechaRecepcion,
                StatusSolicitud = dto.StatusSolicitud,
                FechaSolicitud = dto.FechaSolicitud,
                Origen = dto.Origen,
                Destino = dto.Destino,
                CorreoElectronico = dto.CorreoElectronico,
                NumeroCelular = dto.NumeroCelular,
                MotivoTraslado = dto.MotivoTraslado,
                GuiaTraslado = dto.GuiaTraslado,
                FolioReemo = dto.FolioReemo,
                TipoGanado = dto.TipoGanado,
                HembrasMovilizar = dto.HembrasMovilizar,
                MachosMovilizar = dto.MachosMovilizar,
                MarcaVehiculo = dto.MarcaVehiculo,
                PlacasVehiculo = dto.PlacasVehiculo,
                NombreChofer = dto.NombreChofer,
                PuntosVerificacion = dto.PuntosVerificacion,
                CertificadoMovilizacion = dto.CertificadoMovilizacion,
                DictamenTb = dto.DictamenTb,
                DictamenBr = dto.DictamenBr,
                NumeroFlejes = dto.NumeroFlejes,
                Factura = dto.Factura,
                MarcajeCn = dto.MarcajeCn
            };
            _context.SolicitudInternacions.Add(solicitudInternacion);
            await _context.SaveChangesAsync();
            return solicitudInternacion.IdSolicitudInternacion;
        }
        public async Task<solicitudInternacionDto?> ObtenerSolicitudInternacionAsync(int id)
        {
            return await _context.SolicitudInternacions
                .Where(s => s.IdSolicitudInternacion == id)
                .Select(s => new solicitudInternacionDto {
                    IdSolicitudInternacion = s.IdSolicitudInternacion,
                    FechaSolicitud = s.FechaSolicitud,
                    Origen = s.Origen,
                    Destino = s.Destino,
                    CorreoElectronico = s.CorreoElectronico,
                    NumeroCelular = s.NumeroCelular,
                    MotivoTraslado = s.MotivoTraslado,
                    GuiaTraslado = s.GuiaTraslado,
                    FolioReemo = s.FolioReemo,
                    TipoGanado = s.TipoGanado,
                    HembrasMovilizar = s.HembrasMovilizar,
                    MachosMovilizar = s.MachosMovilizar,
                    MarcaVehiculo = s.MarcaVehiculo,
                    PlacasVehiculo = s.PlacasVehiculo,
                    NombreChofer = s.NombreChofer,
                    PuntosVerificacion = s.PuntosVerificacion,
                    CertificadoMovilizacion = s.CertificadoMovilizacion,
                    DictamenTb = s.DictamenTb,
                    DictamenBr = s.DictamenBr,
                    NumeroFlejes = s.NumeroFlejes,
                    Factura = s.Factura,
                    MarcajeCn = s.MarcajeCn,
                    FechaCaptura = s.FechaCaptura,
                    StatusSolicitud = s.StatusSolicitud,
                    IdUsuario = s.IdUsuario,
                    FechaRecepcion = s.FechaRecepcion,
                    FechaInicioAtencion = s.FechaInicioAtencion,
                    FechaCierreAtencion = s.FechaCierreAtencion,
                    MotivoRechazo = s.MotivoRechazo,
                    Observaciones = s.Observaciones,
                    NombreSolicitante = s.NombreSolicitante,
                    ClaveUpp = s.ClaveUpp
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CatalogoProductore?> ValidarCURPAsync(string idCURP) {
            return await _context.CatalogoProductores
                .Where(p => p.CurpProductor == idCURP)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SubirDocumentoAsync(IFormFile archivo, int idDocumento, int idSolicitud, string observaciones) {

            //Obtiene el nombre corto pafa generar el nombre del archivo
            var catalogoDoc = await _context.CatalogoDocumentos.FindAsync(idDocumento);
            string nombreCorto = catalogoDoc?.DescDocumentoCorto ?? "doc";
            //Define la ruta donde se va a guardar el archivo (Si no existe la crea)
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            string nombreArchivo = $"{idSolicitud}_{nombreCorto}{Path.GetExtension(archivo.FileName)}";
            string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);
            //Carga el doctaumento a la ru
            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }
            //Guarda el registgro en la base de datos
            var documento = new SolicitudInternacionDocumento()
            {
                IdDocumento = idDocumento,
                IdSolicitudInternacion = idSolicitud,
                NombreDocumento = nombreArchivo,
                Observaciones = observaciones,
                FechaCarga = DateTime.Now,
                TipoMime = archivo.ContentType
            };
            _context.SolicitudInternacionDocumentos.Add(documento);
            await _context.SaveChangesAsync();
            //Regresa verdadero porque todo se realizó correctamente
            return true;
        }

    }
}
