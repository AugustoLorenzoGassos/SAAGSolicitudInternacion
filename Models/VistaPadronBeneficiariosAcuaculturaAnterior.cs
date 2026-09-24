using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaPadronBeneficiariosAcuaculturaAnterior
{
    public string? Folio { get; set; }

    public string? NombreBeneficiarios { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public string NombreLocalidad { get; set; } = null!;

    public short PeriodoPadron { get; set; }
}
