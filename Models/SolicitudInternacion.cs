using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class SolicitudInternacion
{
    public int IdSolicitudInternacion { get; set; }

    public DateOnly? FechaSolicitud { get; set; }

    public string? NombreSolicitante { get; set; }

    public short? TipoGanado { get; set; }

    public short? MotivoTraslado { get; set; }

    public string? CertificadoMovilizacion { get; set; }

    public string? Origen { get; set; }

    public string? Destino { get; set; }

    public string? ClaveUpp { get; set; }

    public short? HembrasMovilizar { get; set; }

    public short? MachosMovilizar { get; set; }

    public string? PlacasVehiculo { get; set; }

    public string? MarcaVehúclo { get; set; }

    public string? NombreChofer { get; set; }

    public string? NumeroFlejes { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public virtual CatalogoProductoresUpp? ClaveUppNavigation { get; set; }

    public virtual CatalogoMotivoTraslado? MotivoTrasladoNavigation { get; set; }

    public virtual ICollection<SolicitudInternacionDocumento> SolicitudInternacionDocumentos { get; set; } = new List<SolicitudInternacionDocumento>();

    public virtual CatalogoTipoGanado? TipoGanadoNavigation { get; set; }
}
