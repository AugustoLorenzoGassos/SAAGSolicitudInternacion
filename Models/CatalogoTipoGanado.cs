using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoTipoGanado
{
    public short IdTipoGanado { get; set; }

    public string? DescTipoGanado { get; set; }

    public virtual ICollection<SolicitudInternacion> SolicitudInternacions { get; set; } = new List<SolicitudInternacion>();
}
