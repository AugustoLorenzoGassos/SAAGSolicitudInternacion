using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class ProduccionUpp
{
    public int IdRegistroProduccion { get; set; }

    public int IdEtapaRegistro { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? IdUsuario { get; set; }

    public int? IdProductorUpp { get; set; }

    public int? Vientres { get; set; }

    public int? Semental { get; set; }

    public int? Vaquillas1214 { get; set; }

    public int? NovillosToretes12 { get; set; }

    public int? CriasHembras812 { get; set; }

    public int? CriasMachos812 { get; set; }

    public int? BecerrasLactantes08 { get; set; }

    public int? BecerrosLactantes08 { get; set; }

    public int? CantidadCabezas { get; set; }

    public int? CantidadCabezasConArete { get; set; }

    public int? CantidadCabezasSinArete { get; set; }

    public int? CantidadCabezasAretesGratuitos { get; set; }

    public int? CantidadCabezasAretesProductor { get; set; }

    public int? IdRaza { get; set; }

    public int? IdUsoRaza { get; set; }

    public string? Observaciones { get; set; }

    public bool? CuestionarioHatos { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public virtual CatalogoProductoresUpp? IdProductorUppNavigation { get; set; }

    public virtual CatalogoRaza? IdRazaNavigation { get; set; }

    public virtual CatalogoUso? IdUsoRazaNavigation { get; set; }

    public virtual CatalogoUsuario? IdUsuarioNavigation { get; set; }
}
