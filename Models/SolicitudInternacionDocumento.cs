using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class SolicitudInternacionDocumento
{
    public int IdSolicitudInternacionDocumento { get; set; }

    public int? IdSolicitudInternacion { get; set; }

    public int? IdDocumento { get; set; }

    public string? NombreDocumento { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaCarga { get; set; }

    public string? TipoMime { get; set; }

    public bool? StatusDocumento { get; set; }

    public virtual CatalogoDocumento? IdDocumentoNavigation { get; set; }

    public virtual SolicitudInternacion? IdSolicitudInternacionNavigation { get; set; }
}
