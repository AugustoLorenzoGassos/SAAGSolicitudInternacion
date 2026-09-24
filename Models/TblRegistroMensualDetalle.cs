using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class TblRegistroMensualDetalle
{
    public int IdReporteMensualAccion { get; set; }

    public int IdReporteMensual { get; set; }

    public int IdProductor { get; set; }

    public DateTime? FechaReporte { get; set; }

    public short? CpsMcm { get; set; }

    public short? CpcFlotac { get; set; }

    public short? CpcSedim { get; set; }

    public short? CpcBearm { get; set; }

    public short? DxScBh { get; set; }

    public short? DxScSc { get; set; }

    public short? Mastitis { get; set; }

    public short? DiasGestacion { get; set; }

    public short? AsesoramientoZoosanitarui { get; set; }

    public short? ProfilaxisEquina { get; set; }

    public short? Total { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? IdUsuario { get; set; }

    public virtual CatalogoProductore IdProductorNavigation { get; set; } = null!;

    public virtual TblRegistroMensual IdReporteMensualNavigation { get; set; } = null!;
}
