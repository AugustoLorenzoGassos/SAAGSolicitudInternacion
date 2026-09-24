using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaPyhonBeneficiariosResuman
{
    public string IdProyecto { get; set; } = null!;

    public string? NombreProyectoCorto { get; set; }

    public int? TotalBeneficiarios { get; set; }
}
