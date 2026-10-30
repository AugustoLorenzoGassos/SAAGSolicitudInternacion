using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoMunicipio
{
    public string ClaveMunicipio { get; set; } = null!;

    public short? IdRegion { get; set; }

    public short? IdDistritoElectoral { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public string? NombreAlcalde { get; set; }

    public string? PartidoAlcalde { get; set; }

    public string? TipoZona { get; set; }

    public virtual ICollection<CatalogoLocalidade> CatalogoLocalidades { get; set; } = new List<CatalogoLocalidade>();

    public virtual CatalogoDistritosLocale? IdDistritoElectoralNavigation { get; set; }

    public virtual CatalogoRegione? IdRegionNavigation { get; set; }
}
