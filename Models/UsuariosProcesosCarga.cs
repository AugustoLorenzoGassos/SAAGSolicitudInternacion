using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class UsuariosProcesosCarga
{
    public int IdLoteCarga { get; set; }

    public string? IdUsuario { get; set; }

    public DateTime? FechaCarga { get; set; }

    public string? NombreArchivo { get; set; }

    public int? RegistrosLeidos { get; set; }

    public int? RegistrosCargados { get; set; }

    public int? RegistrosError { get; set; }

    public virtual CatalogoUsuario? IdUsuarioNavigation { get; set; }
}
