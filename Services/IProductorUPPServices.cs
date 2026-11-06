using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.Services
{
    public interface IProductorUPPServices
    {
        Task<bool> GuardarProductorConUppAsync(productorUppDto dto);
    }
}
