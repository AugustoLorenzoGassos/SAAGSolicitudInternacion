using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaPadronBeneficiariosIatf
{
    public short PeriodoPadron { get; set; }

    public string IdProyecto { get; set; } = null!;

    public string NombreProyecto { get; set; } = null!;

    public int IdBeneficiario { get; set; }

    public string? NombreBeneficiarios { get; set; }

    public string? Curp { get; set; }

    public string? CveMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public string? CveLocalidad { get; set; }

    public string NombreLocalidad { get; set; } = null!;

    public short IdRegion { get; set; }

    public string? NombreRegion { get; set; }

    public short IdDistritoElectoral { get; set; }

    public string? NombreDistritoElectoral { get; set; }

    public string? FolioVientres { get; set; }

    public string? FolioSemental { get; set; }

    public string? NumeroEntrega1 { get; set; }

    public string? NumeroEntrega2 { get; set; }

    public short? Sementales { get; set; }

    public short? Vientres { get; set; }
}
