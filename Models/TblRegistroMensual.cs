using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class TblRegistroMensual
{
    public int IdReporteMensual { get; set; }

    public string? IdUsuario { get; set; }

    public int? IdLaboratorio { get; set; }

    public short? MesReporte { get; set; }

    public short? AñoReporte { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual CatalogoLaboratorio? IdLaboratorioNavigation { get; set; }

    public virtual CatalogoUsuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<TblBitacoraElectronica> TblBitacoraElectronicas { get; set; } = new List<TblBitacoraElectronica>();

    public virtual ICollection<TblRegistroMensualDetalle> TblRegistroMensualDetalles { get; set; } = new List<TblRegistroMensualDetalle>();
}
