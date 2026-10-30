using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoStatusSolicitud
{
    public int IdStatusSolicitud { get; set; }

    public string? DescStatusSolicitud { get; set; }

    public virtual ICollection<SolicitudInternacion> SolicitudInternacions { get; set; } = new List<SolicitudInternacion>();
}
