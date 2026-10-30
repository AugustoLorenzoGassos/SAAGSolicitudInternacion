using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoProductoresUpp
{
    public int IdProductorUpp { get; set; }

    public int? IdProductor { get; set; }

    public string ClaveUpp { get; set; } = null!;

    public string? NombreUpp { get; set; }

    public string? CveMunicipio { get; set; }

    public string? CveLocalidad { get; set; }

    public double? Latitud { get; set; }

    public double? Longitud { get; set; }

    public string? Ubicacion { get; set; }

    public short? TotalHato { get; set; }

    public short? TotalProbados { get; set; }

    public bool? EspecieRegistadaBovino { get; set; }

    public bool? EspecieRegistadaEquino { get; set; }

    public bool? EspecieRegistadaOvino { get; set; }

    public bool? EspecieRegistadaPorcino { get; set; }

    public bool? EspecieTrabajadaBovino { get; set; }

    public bool? EspecieTrabajadaEquino { get; set; }

    public bool? EspecieTrabajadaOvino { get; set; }

    public bool? EspecieTrabajadaPorcino { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? IdUsuario { get; set; }

    public virtual CatalogoLocalidade? CatalogoLocalidade { get; set; }

    public virtual CatalogoProductore? IdProductorNavigation { get; set; }

    public virtual ICollection<ProduccionUpp> ProduccionUpps { get; set; } = new List<ProduccionUpp>();

    public virtual ICollection<SolicitudInternacion> SolicitudInternacions { get; set; } = new List<SolicitudInternacion>();

    public virtual ICollection<TblBitacoraElectronica> TblBitacoraElectronicas { get; set; } = new List<TblBitacoraElectronica>();
}
