using solicitudInternacion.Models.DTOs;

namespace solicitudInternacion.Services
{
    public interface IUpp
    {

        Task<CatalogoProductoresUppDto?> LeerRegistroUPP(string claveUPP);
        Task<UppDTO?> ObtenerUppPorClaveAsync(string claveUpp);

    }
}
