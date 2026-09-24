using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoMotivoTraslado
{
    public short IdMotivoTraslado { get; set; }

    public string? DescMotivoTraslado { get; set; }

    public virtual ICollection<SolicitudInternacion> SolicitudInternacions { get; set; } = new List<SolicitudInternacion>();
}
