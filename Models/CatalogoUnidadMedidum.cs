using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoUnidadMedidum
{
    public short IdUnidadMedida { get; set; }

    public string? DescripcionUnidadMedida { get; set; }

    public virtual ICollection<CatalogoApoyo> CatalogoApoyos { get; set; } = new List<CatalogoApoyo>();
}
