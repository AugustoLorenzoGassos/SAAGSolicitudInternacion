using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class PadronBeneficiariosItafapoyo
{
    public short No { get; set; }

    public string Municipio { get; set; } = null!;

    public string Localidad { get; set; } = null!;

    public string? ResponsableSedarpa { get; set; }

    public string Beneficiario { get; set; } = null!;

    public byte? EvaluacionReproductiva { get; set; }

    public decimal? EvaluacionReproductiva2 { get; set; }

    public byte? ServicioDeInseminacion { get; set; }

    public decimal? ServicioDeInseminacion2 { get; set; }
}
