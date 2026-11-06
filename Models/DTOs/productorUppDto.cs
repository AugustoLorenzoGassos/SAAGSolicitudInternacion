namespace solicitudInternacion.Models.DTOs
{
    public class productorUppDto
    {
        public string? nombreProductor { get; set; }
        public string? apellidoPaternoProductor { get; set; }
        public string? apellidoMaternoProductor { get; set; }
        public string? generoProductor { get; set; }
        public string? correoProductor { get; set; }
        public string? telefonoProductor { get; set; }
        public string? curpProductor { get; set; }
        public string claveUpp { get; set; } = null!;
        public string? nombreUpp { get; set; }
        public string? cveMunicipio { get; set; }
        public string? cveLocalidad { get; set; }
        public float? latitud { get; set; }
        public float? longitud { get; set; }
    }
}
