using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaPadronBeneficiariosApicultura2025Indigena
{
    public short PeriodoPadron { get; set; }

    public string IdProyecto { get; set; } = null!;

    public string NombreProyecto { get; set; } = null!;

    public int IdBeneficiario { get; set; }

    public string? Folio { get; set; }

    public string? NombreBeneficiarios { get; set; }

    public string? Curp { get; set; }

    public string? Genero { get; set; }

    public string? FechaNacimiento { get; set; }

    public int? Edad { get; set; }

    public string? CveMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public string? CveLocalidad { get; set; }

    public string NombreLocalidad { get; set; } = null!;

    public short? IdTipoApoyo { get; set; }

    public string? NombreTipoApoyo { get; set; }

    public string? TelefonoBeneficiario { get; set; }

    public string? Municipio { get; set; }

    public string? Localidad { get; set; }

    public string? DescripcionApoyo { get; set; }

    public string? DescripcionUnidadMedida { get; set; }

    public short? Cantidad { get; set; }

    public double? PrecioUnitario { get; set; }

    public double? Importe { get; set; }

    public string? Dictamen { get; set; }

    public string? NombreRegion { get; set; }

    public string? FolioActa { get; set; }
}
