using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaAccionesSeguimiento
{
    public string? NombreLaboratorio { get; set; }

    public short? MesReporte { get; set; }

    public short? AñoReporte { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? NombreProductor { get; set; }

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

    public DateTime? Expr1 { get; set; }

    public DateTime? Expr2 { get; set; }

    public int? IdLaboratorio { get; set; }
}
