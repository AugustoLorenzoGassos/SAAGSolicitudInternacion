using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaPadronBeneficiariosUbicacion
{
    public short PeriodoPadron { get; set; }

    public short IdRegion { get; set; }

    public string? NombreRegion { get; set; }

    public string? CveMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public string? CveLocalidad { get; set; }

    public string NombreLocalidad { get; set; } = null!;

    public string IdProyecto { get; set; } = null!;

    public string NombreProyecto { get; set; } = null!;

    public string? NombreBeneficiarios { get; set; }

    public double? Longitud { get; set; }

    public double? Latitud { get; set; }

    public string? Localidad { get; set; }
}
