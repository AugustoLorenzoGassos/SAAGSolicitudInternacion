using System;
using System.Collections.Generic;

namespace solicitudInternacion.Models;

public partial class PadronBeneficiariosIatf
{
    public int? IdBeneficiario { get; set; }

    public string FolioVientres { get; set; } = null!;

    public string? FolioSemental { get; set; }

    public string Nombre { get; set; } = null!;

    public string? QuienMandaElExpediente { get; set; }

    public byte NDeServiciosVientres { get; set; }

    public string NDeEntrega { get; set; } = null!;

    public byte? Sementales { get; set; }

    public string? NDeEntrega2 { get; set; }

    public string Genero { get; set; } = null!;

    public string? Column10 { get; set; }

    public short? CveMunicipio { get; set; }

    public short? CveLocalidad { get; set; }

    public string Municipio { get; set; } = null!;

    public string Localidad { get; set; } = null!;

    public string? CalleYNumero { get; set; }

    public string NumeroDeTelefono { get; set; } = null!;

    public string? ReferenciaDeComoLlegarAlPredio { get; set; }

    public short? Vientres { get; set; }

    public DateOnly? ActualizacionDeLaUpp { get; set; }

    public string? Observaciones { get; set; }

    public string? Upp { get; set; }

    public string? ProyectoDeInversion { get; set; }
}
