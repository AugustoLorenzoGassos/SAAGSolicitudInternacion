using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoApoyo
{
    public short IdApoyo { get; set; }

    public string? DescripcionApoyo { get; set; }

    public short? IdUnidadMedida { get; set; }

    public double? PrecioUnitario { get; set; }

    public virtual CatalogoUnidadMedidum? IdUnidadMedidaNavigation { get; set; }

    public virtual ICollection<PadronBeneficiariosApoyo> PadronBeneficiariosApoyos { get; set; } = new List<PadronBeneficiariosApoyo>();
}
