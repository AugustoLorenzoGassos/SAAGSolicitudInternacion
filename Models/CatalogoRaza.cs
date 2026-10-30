using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class CatalogoRaza
{
    public int IdRaza { get; set; }

    public string? DescRaza { get; set; }

    public virtual ICollection<ProduccionUpp> ProduccionUpps { get; set; } = new List<ProduccionUpp>();
}
