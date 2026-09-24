using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class PadronBeneficiariosApoyo
{
    public short PeriodoPadron { get; set; }

    public int IdBeneficiario { get; set; }

    public string IdProyecto { get; set; } = null!;

    public short IdApoyo { get; set; }

    public short? Cantidad { get; set; }

    public double? PrecioUnitario { get; set; }

    public virtual CatalogoApoyo IdApoyoNavigation { get; set; } = null!;

    public virtual PadronBeneficiario PadronBeneficiario { get; set; } = null!;
}
