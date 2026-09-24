using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaPythonBeneficiariosMunicipioResuman
{
    public string IdProyecto { get; set; } = null!;

    public string? NombreProyectoCorto { get; set; }

    public string? CveMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public int? TotalBeneficiarios { get; set; }
}
