using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaPadronBeneficiariosAcuacultura
{
    public short PeriodoPadron { get; set; }

    public int IdBeneficiario { get; set; }

    public string? CveMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public string? CveLocalidad { get; set; }

    public string NombreLocalidad { get; set; } = null!;

    public string IdProyecto { get; set; } = null!;

    public string? NombreBeneficiarios { get; set; }

    public string? DescripcionApoyo { get; set; }

    public string? DescripcionUnidadMedida { get; set; }

    public short? Cantidad { get; set; }

    public double? PrecioUnitario { get; set; }

    public double? Importe { get; set; }

    public short IdRegion { get; set; }

    public string? NombreRegion { get; set; }

    public short IdDistritoElectoral { get; set; }

    public string? NombreDistritoElectoral { get; set; }
}
