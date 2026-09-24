using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoProductore
{
    public int IdProductor { get; set; }

    public string? NombreProductor { get; set; }

    public string? ApellidoPaternoProductor { get; set; }

    public string? ApellidoMaternoProductor { get; set; }

    public string? GeneroProductor { get; set; }

    public string? CveMunicipio { get; set; }

    public string? CveLocalidad { get; set; }

    public string? DomicilioProductor { get; set; }

    public string? CurpProductor { get; set; }

    public string? CorreoProductor { get; set; }

    public string? TelefonoProductor { get; set; }

    public bool? EspecieRegistadaBovino { get; set; }

    public bool? EspecieRegistadaEquino { get; set; }

    public bool? EspecieRegistadaOvino { get; set; }

    public bool? EspecieRegistadaPorcino { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? IdUsuario { get; set; }

    public virtual ICollection<CatalogoProductoresUpp> CatalogoProductoresUpps { get; set; } = new List<CatalogoProductoresUpp>();

    public virtual ICollection<TblRegistroMensualDetalle> TblRegistroMensualDetalles { get; set; } = new List<TblRegistroMensualDetalle>();
}
