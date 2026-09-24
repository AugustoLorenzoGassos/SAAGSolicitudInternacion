using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoUsuario
{
    public string IdUsuario { get; set; } = null!;

    public string? ContraseñaUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? RolUsuario { get; set; }

    public string? StatusUsuario { get; set; }

    public virtual ICollection<TblBitacoraElectronica> TblBitacoraElectronicas { get; set; } = new List<TblBitacoraElectronica>();

    public virtual ICollection<TblRegistroMensual> TblRegistroMensuals { get; set; } = new List<TblRegistroMensual>();
}
