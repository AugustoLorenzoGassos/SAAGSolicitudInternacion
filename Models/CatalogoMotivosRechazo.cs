using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoMotivosRechazo
{
    public int IdMotivoRechazo { get; set; }

    public string? DescMotivoRechazo { get; set; }

    public virtual ICollection<SolicitudInternacion> SolicitudInternacions { get; set; } = new List<SolicitudInternacion>();
}
