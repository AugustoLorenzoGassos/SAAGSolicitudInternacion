using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoLocalidade
{
    public string ClaveMunicipio { get; set; } = null!;

    public string ClaveLocalidad { get; set; } = null!;

    public string NombreLocalidad { get; set; } = null!;

    public double? Longitud { get; set; }

    public double? Latitud { get; set; }

    public virtual ICollection<CatalogoProductoresUpp> CatalogoProductoresUpps { get; set; } = new List<CatalogoProductoresUpp>();

    public virtual CatalogoMunicipio ClaveMunicipioNavigation { get; set; } = null!;

    public virtual ICollection<PadronBeneficiario> PadronBeneficiarios { get; set; } = new List<PadronBeneficiario>();
}
