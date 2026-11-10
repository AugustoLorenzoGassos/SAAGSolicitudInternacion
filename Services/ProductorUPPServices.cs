using Microsoft.EntityFrameworkCore;
using solicitudInternacion.Models;
using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.Services
{
    public class ProductorUPPServices : IProductorUPPServices
    {
        private readonly SedarpaContext _context;

        public ProductorUPPServices(SedarpaContext context)
        {
            _context = context;
        }

        public async Task<bool> GuardarProductorConUppAsync(productorUppDto dto)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try 
            {
                // 1. Mapear y/o buscar el Productor
                var productor = await _context.CatalogoProductores
                    .FirstOrDefaultAsync(p => p.CurpProductor == dto.curpProductor);

                if(productor == null)
                {
                    // 2. Crear nuevo Productor
                    productor = new CatalogoProductore
                    {
                        CurpProductor = dto.curpProductor?.ToUpper(),
                        NombreProductor = dto.nombreProductor?.ToUpper(),
                        ApellidoPaternoProductor = dto.apellidoPaternoProductor?.ToUpper(),
                        ApellidoMaternoProductor = dto.apellidoMaternoProductor?.ToUpper(),
                        GeneroProductor = dto.generoProductor,
                        CorreoProductor = dto.correoProductor,
                        TelefonoProductor = dto.telefonoProductor
                    };
                    _context.CatalogoProductores.Add(productor);
                    await _context.SaveChangesAsync();
                }

                var upp = new Models.CatalogoProductoresUpp
                {
                    ClaveUpp = dto.claveUpp,
                    NombreUpp = dto.nombreUpp?.ToUpper(),
                    CveMunicipio = dto.cveMunicipio,
                    CveLocalidad = dto.cveLocalidad,
                    Latitud = dto.latitud,
                    Longitud = dto.longitud,
                    IdProductor = productor.IdProductor// Asumiendo que ProductorId es la clave primaria de CatalogoProductore
                };
                _context.CatalogoProductoresUpps.Add(upp);
                await _context.SaveChangesAsync();

                // Confirmar transacción
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction.RollbackAsync();
                throw;
            }
            
        }
    }
}
