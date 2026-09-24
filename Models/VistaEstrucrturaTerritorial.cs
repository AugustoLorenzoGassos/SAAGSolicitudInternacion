using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaEstrucrturaTerritorial
{
    public string ClaveMunicipio { get; set; } = null!;

    public string NombreMunicipio { get; set; } = null!;

    public string? NombreRegion { get; set; }

    public string? NombreDistritoElectoral { get; set; }

    public string? NombreAlcalde { get; set; }

    public string? PartidoAlcalde { get; set; }
}
