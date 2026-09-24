using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class TblBitacoraElectronica
{
    public int IdBitacoraElectronica { get; set; }

    public int? IdReporteMensual { get; set; }

    public DateTime? FechaBitacora { get; set; }

    public string? CasoBitacora { get; set; }

    public string? FolioBitacora { get; set; }

    public int? IdProductorUpp { get; set; }

    public DateTime? BitacoraDesparacitacionFecha { get; set; }

    public string? BitacoraDesparacitacionDesparasitante { get; set; }

    public DateTime? BitacoraVacunacionFecha { get; set; }

    public string? BitacoraVacunacionVacuna { get; set; }

    public short? ReproduccionHembras { get; set; }

    public short? ReproduccionHembrasPalpadas { get; set; }

    public short? ReproduccionHembrasVacias { get; set; }

    public short? ReproduccionHembrasGestantes { get; set; }

    public short? ReproduccionHembrasEa { get; set; }

    public short? ReproduccionHembrasIa { get; set; }

    public short? CoproMuestras { get; set; }

    public short? CoproGastroPositivos { get; set; }

    public short? CoproGastroParasitos { get; set; }

    public short? CoproGastroPositivosCoccidias { get; set; }

    public short? CoproPositivosFasciola { get; set; }

    public short? CoproPositivosVerminosis { get; set; }

    public short? SanguineoMuestrasBh { get; set; }

    public short? SanguineoMuestrasHp { get; set; }

    public short? SanguineoAnaplasma { get; set; }

    public short? SanguineoBebesia { get; set; }

    public string? SanguineoObservaciones { get; set; }

    public short? ServiciosCmt { get; set; }

    public short? ServicioPdedental { get; set; }

    public short? ServicioPdelobo { get; set; }

    public short? ServicioPdelimado { get; set; }

    public short? ServicioZooasesoramiento { get; set; }

    public short? ServicioZooconsulta { get; set; }

    public short? ServicioZoodesparasitación { get; set; }

    public short? ServicioZoovacunación { get; set; }

    public string? ServicioZoootro { get; set; }

    public string? TrataminetoRocomndado { get; set; }

    public DateTime? CitaProxima { get; set; }

    public string? MedicoResponsable { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? IdUsuario { get; set; }

    public virtual CatalogoProductoresUpp? IdProductorUppNavigation { get; set; }

    public virtual TblRegistroMensual? IdReporteMensualNavigation { get; set; }

    public virtual CatalogoUsuario? IdUsuarioNavigation { get; set; }
}
