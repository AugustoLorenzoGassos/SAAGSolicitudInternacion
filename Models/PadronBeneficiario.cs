using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class PadronBeneficiario
{
    public short PeriodoPadron { get; set; }

    public int IdBeneficiario { get; set; }

    public string IdProyecto { get; set; } = null!;

    public string? NombreBeneficiarios { get; set; }

    public string? Curp { get; set; }

    public string? Folio { get; set; }

    public short? IdTipoApoyo { get; set; }

    public string? CveMunicipio { get; set; }

    public string? CveLocalidad { get; set; }

    public string? TelefonoBeneficiario { get; set; }

    public string? Municipio { get; set; }

    public string? Localidad { get; set; }

    public string? Dictamen { get; set; }

    public string? FolioActa { get; set; }

    public short? IdRegion { get; set; }

    public string? Region { get; set; }

    public string? ReferenciasComunidad { get; set; }

    public string? FolioVientres { get; set; }

    public string? FolioSemental { get; set; }

    public string? NumeroEntrega1 { get; set; }

    public string? NumeroEntrega2 { get; set; }

    public short? Sementales { get; set; }

    public short? Vientres { get; set; }

    public double? Latitud { get; set; }

    public double? Longitud { get; set; }

    public virtual CatalogoLocalidade? CatalogoLocalidade { get; set; }

    public virtual CatalogoProyecto IdProyectoNavigation { get; set; } = null!;

    public virtual CatalogoTipoApoyo? IdTipoApoyoNavigation { get; set; }

    public virtual ICollection<PadronBeneficiariosApoyo> PadronBeneficiariosApoyos { get; set; } = new List<PadronBeneficiariosApoyo>();
}
