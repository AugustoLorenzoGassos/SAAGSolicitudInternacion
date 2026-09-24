using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoDocumento
{
    public int IdDocumento { get; set; }

    public string? DescDocumento { get; set; }

    public string? DescDocumentoCorto { get; set; }

    public virtual ICollection<SolicitudInternacionDocumento> SolicitudInternacionDocumentos { get; set; } = new List<SolicitudInternacionDocumento>();
}
