using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaPadronProductoresUpp
{
    public string? CurpProductor { get; set; }

    public string? NombreProductor { get; set; }

    public string? ApellidoPaternoProductor { get; set; }

    public string? ApellidoMaternoProductor { get; set; }

    public string? GeneroProductor { get; set; }

    public string? CorreoProductor { get; set; }

    public string? TelefonoProductor { get; set; }

    public bool? EspecieRegistadaBovino { get; set; }

    public bool? EspecieRegistadaEquino { get; set; }

    public bool? EspecieRegistadaOvino { get; set; }

    public bool? EspecieRegistadaPorcino { get; set; }

    public string? ClaveUpp { get; set; }

    public string? NombreUpp { get; set; }

    public string? CveMunicipio { get; set; }

    public string? NombreMunicipio { get; set; }

    public string? CveLocalidad { get; set; }

    public string? NombreLocalidad { get; set; }

    public double? Latitud { get; set; }

    public double? Longitud { get; set; }

    public short? TotalHato { get; set; }

    public short? TotalProbados { get; set; }

    public bool? EspecieTrabajadaBovino { get; set; }

    public bool? EspecieTrabajadaEquino { get; set; }

    public bool? EspecieTrabajadaOvino { get; set; }

    public bool? EspecieTrabajadaPorcino { get; set; }
}
