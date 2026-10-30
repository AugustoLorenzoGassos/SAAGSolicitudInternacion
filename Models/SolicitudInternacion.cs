using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class SolicitudInternacion
{
    public int IdSolicitudInternacion { get; set; }

    public DateOnly? FechaSolicitud { get; set; }

    public string? Origen { get; set; }

    public string? Destino { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? NumeroCelular { get; set; }

    public short? MotivoTraslado { get; set; }

    public string? GuiaTraslado { get; set; }

    public string? FolioReemo { get; set; }

    public short? TipoGanado { get; set; }

    public short? HembrasMovilizar { get; set; }

    public short? MachosMovilizar { get; set; }

    public string? MarcaVehiculo { get; set; }

    public string? PlacasVehiculo { get; set; }

    public string? NombreChofer { get; set; }

    public string? PuntosVerificacion { get; set; }

    public string? CertificadoMovilizacion { get; set; }

    public string? DictamenTb { get; set; }

    public string? DictamenBr { get; set; }

    public string? NumeroFlejes { get; set; }

    public string? Factura { get; set; }

    public string? MarcajeCn { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public int? StatusSolicitud { get; set; }

    public string? IdUsuario { get; set; }

    public DateTime? FechaRecepcion { get; set; }

    public DateTime? FechaInicioAtencion { get; set; }

    public DateTime? FechaCierreAtencion { get; set; }

    public int? MotivoRechazo { get; set; }

    public string? Observaciones { get; set; }

    public string? NombreSolicitante { get; set; }

    public string? ClaveUpp { get; set; }

    public virtual CatalogoProductoresUpp? ClaveUppNavigation { get; set; }

    public virtual CatalogoUsuario? IdUsuarioNavigation { get; set; }

    public virtual CatalogoMotivosRechazo? MotivoRechazoNavigation { get; set; }

    public virtual CatalogoMotivoTraslado? MotivoTrasladoNavigation { get; set; }

    public virtual ICollection<SolicitudInternacionDocumento> SolicitudInternacionDocumentos { get; set; } = new List<SolicitudInternacionDocumento>();

    public virtual CatalogoStatusSolicitud? StatusSolicitudNavigation { get; set; }

    public virtual CatalogoTipoGanado? TipoGanadoNavigation { get; set; }
}
