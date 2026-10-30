using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoUso
{
    public int IdUsoRaza { get; set; }

    public string? DescUsoRaza { get; set; }

    public virtual ICollection<ProduccionUpp> ProduccionUpps { get; set; } = new List<ProduccionUpp>();
}
