using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class VistaBitacoraElectronica
{
    public string? NombreLaboratorio { get; set; }

    public short? MesReporte { get; set; }

    public short? AñoReporte { get; set; }

    public string? ClaveUpp { get; set; }

    public string? NombreProductor { get; set; }

    public string? ApellidoPaternoProductor { get; set; }

    public string? ApellidoMaternoProductor { get; set; }

    public DateTime? FechaCapturaRegistgroMensual { get; set; }

    public DateTime? FechaActualizacionRegistroMensual { get; set; }

    public DateTime? FechaBitacora { get; set; }

    public string? CasoBitacora { get; set; }

    public string? FolioBitacora { get; set; }

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

    public DateTime? FechaCapturaBitacora { get; set; }

    public DateTime? FechaActualizacionBitacora { get; set; }

    public int? IdLaboratorio { get; set; }
}
