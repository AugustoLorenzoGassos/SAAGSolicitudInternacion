using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoLaboratorio
{
    public int IdLaboratoio { get; set; }

    public string? NombreLaboratorio { get; set; }

    public virtual ICollection<TblRegistroMensual> TblRegistroMensuals { get; set; } = new List<TblRegistroMensual>();
}
