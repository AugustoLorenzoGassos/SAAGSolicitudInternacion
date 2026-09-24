using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace solicitudInternacion.Models;

public partial class SedarpaContext : DbContext
{
    public SedarpaContext()
    {
    }

    public SedarpaContext(DbContextOptions<SedarpaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatalogoApoyo> CatalogoApoyos { get; set; }

    public virtual DbSet<CatalogoDistritosLocale> CatalogoDistritosLocales { get; set; }

    public virtual DbSet<CatalogoDocumento> CatalogoDocumentos { get; set; }

    public virtual DbSet<CatalogoLaboratorio> CatalogoLaboratorios { get; set; }

    public virtual DbSet<CatalogoLocalidade> CatalogoLocalidades { get; set; }

    public virtual DbSet<CatalogoMotivoTraslado> CatalogoMotivoTraslados { get; set; }

    public virtual DbSet<CatalogoMunicipio> CatalogoMunicipios { get; set; }

    public virtual DbSet<CatalogoProductore> CatalogoProductores { get; set; }

    public virtual DbSet<CatalogoProductoresUpp> CatalogoProductoresUpps { get; set; }

    public virtual DbSet<CatalogoProyecto> CatalogoProyectos { get; set; }

    public virtual DbSet<CatalogoRegione> CatalogoRegiones { get; set; }

    public virtual DbSet<CatalogoRegionesEstatal> CatalogoRegionesEstatals { get; set; }

    public virtual DbSet<CatalogoTipoApoyo> CatalogoTipoApoyos { get; set; }

    public virtual DbSet<CatalogoTipoGanado> CatalogoTipoGanados { get; set; }

    public virtual DbSet<CatalogoUnidadMedidum> CatalogoUnidadMedida { get; set; }

    public virtual DbSet<CatalogoUsuario> CatalogoUsuarios { get; set; }

    public virtual DbSet<PadronBeneficiario> PadronBeneficiarios { get; set; }

    public virtual DbSet<PadronBeneficiariosApoyo> PadronBeneficiariosApoyos { get; set; }

    public virtual DbSet<PadronBeneficiariosIatf> PadronBeneficiariosIatfs { get; set; }

    public virtual DbSet<PadronBeneficiariosItafapoyo> PadronBeneficiariosItafapoyos { get; set; }

    public virtual DbSet<SolicitudInternacion> SolicitudInternacions { get; set; }

    public virtual DbSet<SolicitudInternacionDocumento> SolicitudInternacionDocumentos { get; set; }

    public virtual DbSet<TblBitacoraElectronica> TblBitacoraElectronicas { get; set; }

    public virtual DbSet<TblRegistroMensual> TblRegistroMensuals { get; set; }

    public virtual DbSet<TblRegistroMensualDetalle> TblRegistroMensualDetalles { get; set; }

    public virtual DbSet<VistaAccionesSeguimiento> VistaAccionesSeguimientos { get; set; }

    public virtual DbSet<VistaBitacoraElectronica> VistaBitacoraElectronicas { get; set; }

    public virtual DbSet<VistaEstrucrturaTerritorial> VistaEstrucrturaTerritorials { get; set; }

    public virtual DbSet<VistaEvaluacionReproductiva2025Indigena> VistaEvaluacionReproductiva2025Indigenas { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosAcuacultura> VistaPadronBeneficiariosAcuaculturas { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosAcuaculturaAnterior> VistaPadronBeneficiariosAcuaculturaAnteriors { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosApicultura> VistaPadronBeneficiariosApiculturas { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosApicultura2025Indigena> VistaPadronBeneficiariosApicultura2025Indigenas { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosEvaluacionReproductiva> VistaPadronBeneficiariosEvaluacionReproductivas { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosIatf> VistaPadronBeneficiariosIatfs { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosIfpaptev> VistaPadronBeneficiariosIfpaptevs { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosServicioInseminacion> VistaPadronBeneficiariosServicioInseminacions { get; set; }

    public virtual DbSet<VistaPadronBeneficiariosUbicacion> VistaPadronBeneficiariosUbicacions { get; set; }

    public virtual DbSet<VistaPadronIfpaptev2025Indigena> VistaPadronIfpaptev2025Indigenas { get; set; }

    public virtual DbSet<VistaPadronProductoresUpp> VistaPadronProductoresUpps { get; set; }

    public virtual DbSet<VistaPyhonBeneficiariosResuman> VistaPyhonBeneficiariosResumen { get; set; }

    public virtual DbSet<VistaPythonBeneficiariosMunicipioResuman> VistaPythonBeneficiariosMunicipioResumen { get; set; }

    public virtual DbSet<VistaServiciosInseminacion2025Indigena> VistaServiciosInseminacion2025Indigenas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SEDARPA;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogoApoyo>(entity =>
        {
            entity.HasKey(e => e.IdApoyo);

            entity.ToTable("catalogoApoyos");

            entity.Property(e => e.DescripcionApoyo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionApoyo");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.CatalogoApoyos)
                .HasForeignKey(d => d.IdUnidadMedida)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_catalogoApoyos_catalogoUnidadMedida");
        });

        modelBuilder.Entity<CatalogoDistritosLocale>(entity =>
        {
            entity.HasKey(e => e.IdDistritoElectoral);

            entity.ToTable("catalogoDistritosLocales");

            entity.Property(e => e.NombreDistritoElectoral)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreDistritoElectoral");
        });

        modelBuilder.Entity<CatalogoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdDocumento);

            entity.ToTable("catalogoDocumentos");

            entity.Property(e => e.IdDocumento).HasColumnName("idDocumento");
            entity.Property(e => e.DescDocumento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descDocumento");
            entity.Property(e => e.DescDocumentoCorto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descDocumentoCorto");
        });

        modelBuilder.Entity<CatalogoLaboratorio>(entity =>
        {
            entity.HasKey(e => e.IdLaboratoio);

            entity.ToTable("catalogoLaboratorios");

            entity.Property(e => e.NombreLaboratorio)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombreLaboratorio");
        });

        modelBuilder.Entity<CatalogoLocalidade>(entity =>
        {
            entity.HasKey(e => new { e.ClaveMunicipio, e.ClaveLocalidad });

            entity.ToTable("catalogoLocalidades");

            entity.Property(e => e.ClaveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("claveMunicipio");
            entity.Property(e => e.ClaveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("claveLocalidad");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");

            entity.HasOne(d => d.ClaveMunicipioNavigation).WithMany(p => p.CatalogoLocalidades)
                .HasForeignKey(d => d.ClaveMunicipio)
                .HasConstraintName("FK_catalogoLocalidades_catalogoMunicipios");
        });

        modelBuilder.Entity<CatalogoMotivoTraslado>(entity =>
        {
            entity.HasKey(e => e.IdMotivoTraslado);

            entity.ToTable("catalogoMotivoTraslado");

            entity.Property(e => e.IdMotivoTraslado).HasColumnName("idMotivoTraslado");
            entity.Property(e => e.DescMotivoTraslado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descMotivoTraslado");
        });

        modelBuilder.Entity<CatalogoMunicipio>(entity =>
        {
            entity.HasKey(e => e.ClaveMunicipio);

            entity.ToTable("catalogoMunicipios");

            entity.Property(e => e.ClaveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("claveMunicipio");
            entity.Property(e => e.NombreAlcalde)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreAlcalde");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.PartidoAlcalde)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("partidoAlcalde");

            entity.HasOne(d => d.IdDistritoElectoralNavigation).WithMany(p => p.CatalogoMunicipios)
                .HasForeignKey(d => d.IdDistritoElectoral)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_catalogoMunicipios_catalogoDistritosLocales");

            entity.HasOne(d => d.IdRegionNavigation).WithMany(p => p.CatalogoMunicipios)
                .HasForeignKey(d => d.IdRegion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_catalogoMunicipios_catalogoRegiones");
        });

        modelBuilder.Entity<CatalogoProductore>(entity =>
        {
            entity.HasKey(e => e.IdProductor);

            entity.ToTable("catalogoProductores");

            entity.Property(e => e.ApellidoMaternoProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidoMaternoProductor");
            entity.Property(e => e.ApellidoPaternoProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidoPaternoProductor");
            entity.Property(e => e.CorreoProductor)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("correoProductor");
            entity.Property(e => e.CurpProductor)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("curpProductor");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.DomicilioProductor)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("domicilioProductor");
            entity.Property(e => e.EspecieRegistadaBovino).HasColumnName("especieRegistadaBovino");
            entity.Property(e => e.EspecieRegistadaEquino).HasColumnName("especieRegistadaEquino");
            entity.Property(e => e.EspecieRegistadaOvino).HasColumnName("especieRegistadaOvino");
            entity.Property(e => e.EspecieRegistadaPorcino).HasColumnName("especieRegistadaPorcino");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaCaptura)
                .HasColumnType("datetime")
                .HasColumnName("fechaCaptura");
            entity.Property(e => e.GeneroProductor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("generoProductor");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.NombreProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreProductor");
            entity.Property(e => e.TelefonoProductor)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefonoProductor");
        });

        modelBuilder.Entity<CatalogoProductoresUpp>(entity =>
        {
            entity.HasKey(e => e.IdProductorUpp);

            entity.ToTable("catalogoProductoresUPP");

            entity.HasIndex(e => e.ClaveUpp, "IX_catalogoProductoresUPP").IsUnique();

            entity.Property(e => e.IdProductorUpp).HasColumnName("IdProductorUPP");
            entity.Property(e => e.ClaveUpp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("claveUPP");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.EspecieRegistadaBovino).HasColumnName("especieRegistadaBovino");
            entity.Property(e => e.EspecieRegistadaEquino).HasColumnName("especieRegistadaEquino");
            entity.Property(e => e.EspecieRegistadaOvino).HasColumnName("especieRegistadaOvino");
            entity.Property(e => e.EspecieRegistadaPorcino).HasColumnName("especieRegistadaPorcino");
            entity.Property(e => e.EspecieTrabajadaBovino).HasColumnName("especieTrabajadaBovino");
            entity.Property(e => e.EspecieTrabajadaEquino).HasColumnName("especieTrabajadaEquino");
            entity.Property(e => e.EspecieTrabajadaOvino).HasColumnName("especieTrabajadaOvino");
            entity.Property(e => e.EspecieTrabajadaPorcino).HasColumnName("especieTrabajadaPorcino");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaCaptura)
                .HasColumnType("datetime")
                .HasColumnName("fechaCaptura");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.NombreUpp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreUPP");
            entity.Property(e => e.TotalHato).HasColumnName("totalHato");
            entity.Property(e => e.TotalProbados).HasColumnName("totalProbados");

            entity.HasOne(d => d.IdProductorNavigation).WithMany(p => p.CatalogoProductoresUpps)
                .HasForeignKey(d => d.IdProductor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_catalogoProductoresUPP_catalogoProductores");

            entity.HasOne(d => d.CatalogoLocalidade).WithMany(p => p.CatalogoProductoresUpps)
                .HasForeignKey(d => new { d.CveMunicipio, d.CveLocalidad })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_catalogoProductoresUPP_catalogoLocalidades");
        });

        modelBuilder.Entity<CatalogoProyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto);

            entity.ToTable("catalogoProyectos");

            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("nombreProyecto");
            entity.Property(e => e.NombreProyectoCorto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreProyectoCorto");
        });

        modelBuilder.Entity<CatalogoRegione>(entity =>
        {
            entity.HasKey(e => e.IdRegion);

            entity.ToTable("catalogoRegiones");

            entity.Property(e => e.NombreRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRegion");
        });

        modelBuilder.Entity<CatalogoRegionesEstatal>(entity =>
        {
            entity.HasKey(e => e.IdRegionEstatal);

            entity.ToTable("catalogoRegionesEstatal");

            entity.Property(e => e.IdRegionEstatal).ValueGeneratedNever();
            entity.Property(e => e.NombreRegionEstatal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreRegionEstatal");
        });

        modelBuilder.Entity<CatalogoTipoApoyo>(entity =>
        {
            entity.HasKey(e => e.IdTipoApoyo);

            entity.ToTable("catalogoTipoApoyos");

            entity.Property(e => e.NombreTipoApoyo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoApoyo");
        });

        modelBuilder.Entity<CatalogoTipoGanado>(entity =>
        {
            entity.HasKey(e => e.IdTipoGanado);

            entity.ToTable("catalogoTipoGanado");

            entity.Property(e => e.IdTipoGanado).HasColumnName("idTipoGanado");
            entity.Property(e => e.DescTipoGanado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descTipoGanado");
        });

        modelBuilder.Entity<CatalogoUnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.IdUnidadMedida);

            entity.ToTable("catalogoUnidadMedida");

            entity.Property(e => e.DescripcionUnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionUnidadMedida");
        });

        modelBuilder.Entity<CatalogoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_usuarios");

            entity.ToTable("catalogoUsuarios");

            entity.Property(e => e.IdUsuario)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.ContraseñaUsuario)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("contraseñaUsuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.RolUsuario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("rolUsuario");
            entity.Property(e => e.StatusUsuario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("statusUsuario");
        });

        modelBuilder.Entity<PadronBeneficiario>(entity =>
        {
            entity.HasKey(e => new { e.PeriodoPadron, e.IdBeneficiario, e.IdProyecto }).HasName("PK_padronBeneficiarios_1");

            entity.ToTable("padronBeneficiarios");

            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.Dictamen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dictamen");
            entity.Property(e => e.Folio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folio");
            entity.Property(e => e.FolioActa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("folioActa");
            entity.Property(e => e.FolioSemental)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folioSemental");
            entity.Property(e => e.FolioVientres)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folioVientres");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("localidad");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NumeroEntrega1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numeroEntrega1");
            entity.Property(e => e.NumeroEntrega2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numeroEntrega2");
            entity.Property(e => e.ReferenciasComunidad)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("referenciasComunidad");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("region");
            entity.Property(e => e.Sementales).HasColumnName("sementales");
            entity.Property(e => e.TelefonoBeneficiario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefonoBeneficiario");
            entity.Property(e => e.Vientres).HasColumnName("vientres");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.PadronBeneficiarios)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK_padronBeneficiarios_catalogoProyectos");

            entity.HasOne(d => d.IdTipoApoyoNavigation).WithMany(p => p.PadronBeneficiarios)
                .HasForeignKey(d => d.IdTipoApoyo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_padronBeneficiarios_catalogoTipoApoyos");

            entity.HasOne(d => d.CatalogoLocalidade).WithMany(p => p.PadronBeneficiarios)
                .HasForeignKey(d => new { d.CveMunicipio, d.CveLocalidad })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_padronBeneficiarios_catalogoLocalidades");
        });

        modelBuilder.Entity<PadronBeneficiariosApoyo>(entity =>
        {
            entity.HasKey(e => new { e.PeriodoPadron, e.IdBeneficiario, e.IdProyecto, e.IdApoyo });

            entity.ToTable("padronBeneficiariosApoyos");

            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");

            entity.HasOne(d => d.IdApoyoNavigation).WithMany(p => p.PadronBeneficiariosApoyos)
                .HasForeignKey(d => d.IdApoyo)
                .HasConstraintName("FK_padronBeneficiariosApoyos_catalogoApoyos");

            entity.HasOne(d => d.PadronBeneficiario).WithMany(p => p.PadronBeneficiariosApoyos)
                .HasForeignKey(d => new { d.PeriodoPadron, d.IdBeneficiario, d.IdProyecto })
                .HasConstraintName("FK_padronBeneficiariosApoyos_padronBeneficiarios");
        });

        modelBuilder.Entity<PadronBeneficiariosIatf>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("padronBeneficiariosIATF");

            entity.Property(e => e.ActualizacionDeLaUpp).HasColumnName("ACTUALIZACION_DE_LA_UPP");
            entity.Property(e => e.CalleYNumero)
                .HasMaxLength(500)
                .HasColumnName("CALLE_Y_NUMERO");
            entity.Property(e => e.Column10)
                .HasMaxLength(500)
                .HasColumnName("column10");
            entity.Property(e => e.CveLocalidad).HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio).HasColumnName("cveMunicipio");
            entity.Property(e => e.FolioSemental)
                .HasMaxLength(500)
                .HasColumnName("FOLIO_SEMENTAL");
            entity.Property(e => e.FolioVientres)
                .HasMaxLength(500)
                .HasColumnName("FOLIO_VIENTRES");
            entity.Property(e => e.Genero)
                .HasMaxLength(500)
                .HasColumnName("GENERO");
            entity.Property(e => e.Localidad)
                .HasMaxLength(500)
                .HasColumnName("LOCALIDAD");
            entity.Property(e => e.Municipio)
                .HasMaxLength(500)
                .HasColumnName("MUNICIPIO");
            entity.Property(e => e.NDeEntrega)
                .HasMaxLength(500)
                .HasColumnName("N_DE_ENTREGA");
            entity.Property(e => e.NDeEntrega2)
                .HasMaxLength(500)
                .HasColumnName("N_DE_ENTREGA_2");
            entity.Property(e => e.NDeServiciosVientres).HasColumnName("N_DE_SERVICIOS_VIENTRES");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NumeroDeTelefono)
                .HasMaxLength(500)
                .HasColumnName("NUMERO_DE_TELEFONO");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.ProyectoDeInversion)
                .HasMaxLength(150)
                .HasColumnName("PROYECTO_DE_INVERSION");
            entity.Property(e => e.QuienMandaElExpediente)
                .HasMaxLength(500)
                .HasColumnName("QUIEN_MANDA_EL_EXPEDIENTE");
            entity.Property(e => e.ReferenciaDeComoLlegarAlPredio)
                .HasMaxLength(250)
                .HasColumnName("REFERENCIA_DE_COMO_LLEGAR_AL_PREDIO");
            entity.Property(e => e.Sementales).HasColumnName("SEMENTALES");
            entity.Property(e => e.Upp)
                .HasMaxLength(500)
                .HasColumnName("UPP");
            entity.Property(e => e.Vientres).HasColumnName("VIENTRES");
        });

        modelBuilder.Entity<PadronBeneficiariosItafapoyo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("padronBeneficiariosITAFApoyos");

            entity.Property(e => e.Beneficiario)
                .HasMaxLength(100)
                .HasColumnName("BENEFICIARIO");
            entity.Property(e => e.EvaluacionReproductiva).HasColumnName("EVALUACION_REPRODUCTIVA");
            entity.Property(e => e.EvaluacionReproductiva2)
                .HasColumnType("money")
                .HasColumnName("EVALUACION_REPRODUCTIVA2");
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .HasColumnName("LOCALIDAD");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .HasColumnName("MUNICIPIO");
            entity.Property(e => e.No).HasColumnName("NO");
            entity.Property(e => e.ResponsableSedarpa)
                .HasMaxLength(100)
                .HasColumnName("RESPONSABLE_SEDARPA");
            entity.Property(e => e.ServicioDeInseminacion).HasColumnName("SERVICIO_DE_INSEMINACION");
            entity.Property(e => e.ServicioDeInseminacion2)
                .HasColumnType("money")
                .HasColumnName("SERVICIO_DE_INSEMINACION2");
        });

        modelBuilder.Entity<SolicitudInternacion>(entity =>
        {
            entity.HasKey(e => e.IdSolicitudInternacion);

            entity.ToTable("solicitudInternacion");

            entity.Property(e => e.IdSolicitudInternacion).HasColumnName("idSolicitudInternacion");
            entity.Property(e => e.CertificadoMovilizacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("certificadoMovilizacion");
            entity.Property(e => e.ClaveUpp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("claveUPP");
            entity.Property(e => e.Destino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("destino");
            entity.Property(e => e.FechaCaptura)
                .HasColumnType("datetime")
                .HasColumnName("fechaCaptura");
            entity.Property(e => e.FechaSolicitud).HasColumnName("fechaSolicitud");
            entity.Property(e => e.HembrasMovilizar).HasColumnName("hembrasMovilizar");
            entity.Property(e => e.MachosMovilizar).HasColumnName("machosMovilizar");
            entity.Property(e => e.MarcaVehúclo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marcaVehúclo");
            entity.Property(e => e.MotivoTraslado).HasColumnName("motivoTraslado");
            entity.Property(e => e.NombreChofer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreChofer");
            entity.Property(e => e.NombreSolicitante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreSolicitante");
            entity.Property(e => e.NumeroFlejes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numeroFlejes");
            entity.Property(e => e.Origen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("origen");
            entity.Property(e => e.PlacasVehiculo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("placasVehiculo");
            entity.Property(e => e.TipoGanado).HasColumnName("tipoGanado");

            entity.HasOne(d => d.ClaveUppNavigation).WithMany(p => p.SolicitudInternacions)
                .HasPrincipalKey(p => p.ClaveUpp)
                .HasForeignKey(d => d.ClaveUpp)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_solicitudInternacion_catalogoProductoresUPP");

            entity.HasOne(d => d.MotivoTrasladoNavigation).WithMany(p => p.SolicitudInternacions)
                .HasForeignKey(d => d.MotivoTraslado)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_solicitudInternacion_catalogoMotivoTraslado");

            entity.HasOne(d => d.TipoGanadoNavigation).WithMany(p => p.SolicitudInternacions)
                .HasForeignKey(d => d.TipoGanado)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_solicitudInternacion_catalogoTipoGanado");
        });

        modelBuilder.Entity<SolicitudInternacionDocumento>(entity =>
        {
            entity.HasKey(e => e.IdSolicitudInternacionDocumento);

            entity.ToTable("solicitudInternacionDocumentos");

            entity.Property(e => e.IdSolicitudInternacionDocumento).HasColumnName("idSolicitudInternacionDocumento");
            entity.Property(e => e.FechaCarga)
                .HasColumnType("datetime")
                .HasColumnName("fechaCarga");
            entity.Property(e => e.IdDocumento).HasColumnName("idDocumento");
            entity.Property(e => e.IdSolicitudInternacion).HasColumnName("idSolicitudInternacion");
            entity.Property(e => e.NombreDocumento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreDocumento");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("observaciones");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.SolicitudInternacionDocumentos)
                .HasForeignKey(d => d.IdDocumento)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_solicitudInternacionDocumentos_catalogoDocumentos");

            entity.HasOne(d => d.IdSolicitudInternacionNavigation).WithMany(p => p.SolicitudInternacionDocumentos)
                .HasForeignKey(d => d.IdSolicitudInternacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_solicitudInternacionDocumentos_solicitudInternacion");
        });

        modelBuilder.Entity<TblBitacoraElectronica>(entity =>
        {
            entity.HasKey(e => e.IdBitacoraElectronica);

            entity.ToTable("TblBitacoraElectronica");

            entity.Property(e => e.BitacoraDesparacitacionDesparasitante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bitacoraDesparacitacionDesparasitante");
            entity.Property(e => e.BitacoraDesparacitacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("bitacoraDesparacitacionFecha");
            entity.Property(e => e.BitacoraVacunacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("bitacoraVacunacionFecha");
            entity.Property(e => e.BitacoraVacunacionVacuna)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bitacoraVacunacionVacuna");
            entity.Property(e => e.CasoBitacora)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("casoBitacora");
            entity.Property(e => e.CitaProxima)
                .HasColumnType("datetime")
                .HasColumnName("citaProxima");
            entity.Property(e => e.CoproGastroParasitos).HasColumnName("coproGastroParasitos");
            entity.Property(e => e.CoproGastroPositivos).HasColumnName("coproGastroPositivos");
            entity.Property(e => e.CoproGastroPositivosCoccidias).HasColumnName("coproGastroPositivosCoccidias");
            entity.Property(e => e.CoproMuestras).HasColumnName("coproMuestras");
            entity.Property(e => e.CoproPositivosFasciola).HasColumnName("coproPositivosFasciola");
            entity.Property(e => e.CoproPositivosVerminosis).HasColumnName("coproPositivosVerminosis");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaBitacora)
                .HasColumnType("datetime")
                .HasColumnName("fechaBitacora");
            entity.Property(e => e.FechaCaptura)
                .HasColumnType("datetime")
                .HasColumnName("fechaCaptura");
            entity.Property(e => e.FolioBitacora)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("folioBitacora");
            entity.Property(e => e.IdProductorUpp).HasColumnName("IdProductorUPP");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.MedicoResponsable)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("medicoResponsable");
            entity.Property(e => e.ReproduccionHembras).HasColumnName("reproduccionHembras");
            entity.Property(e => e.ReproduccionHembrasEa).HasColumnName("reproduccionHembrasEA");
            entity.Property(e => e.ReproduccionHembrasGestantes).HasColumnName("reproduccionHembrasGestantes");
            entity.Property(e => e.ReproduccionHembrasIa).HasColumnName("reproduccionHembrasIA");
            entity.Property(e => e.ReproduccionHembrasPalpadas).HasColumnName("reproduccionHembrasPalpadas");
            entity.Property(e => e.ReproduccionHembrasVacias).HasColumnName("reproduccionHembrasVacias");
            entity.Property(e => e.SanguineoAnaplasma).HasColumnName("sanguineoAnaplasma");
            entity.Property(e => e.SanguineoBebesia).HasColumnName("sanguineoBebesia");
            entity.Property(e => e.SanguineoMuestrasBh).HasColumnName("sanguineoMuestrasBH");
            entity.Property(e => e.SanguineoMuestrasHp).HasColumnName("sanguineoMuestrasHP");
            entity.Property(e => e.SanguineoObservaciones)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("sanguineoObservaciones");
            entity.Property(e => e.ServicioPdedental).HasColumnName("servicioPDEDental");
            entity.Property(e => e.ServicioPdelimado).HasColumnName("servicioPDELimado");
            entity.Property(e => e.ServicioPdelobo).HasColumnName("servicioPDELobo");
            entity.Property(e => e.ServicioZooasesoramiento).HasColumnName("servicioZOOAsesoramiento");
            entity.Property(e => e.ServicioZooconsulta).HasColumnName("servicioZOOConsulta");
            entity.Property(e => e.ServicioZoodesparasitación).HasColumnName("servicioZOODesparasitación");
            entity.Property(e => e.ServicioZoootro)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("servicioZOOOtro");
            entity.Property(e => e.ServicioZoovacunación).HasColumnName("servicioZOOVacunación");
            entity.Property(e => e.ServiciosCmt).HasColumnName("serviciosCMT");
            entity.Property(e => e.TrataminetoRocomndado)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("trataminetoRocomndado");

            entity.HasOne(d => d.IdProductorUppNavigation).WithMany(p => p.TblBitacoraElectronicas)
                .HasForeignKey(d => d.IdProductorUpp)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TblBitacoraElectronica_catalogoProductoresUPP");

            entity.HasOne(d => d.IdReporteMensualNavigation).WithMany(p => p.TblBitacoraElectronicas)
                .HasForeignKey(d => d.IdReporteMensual)
                .HasConstraintName("FK_TblBitacoraElectronica_TblRegistroMensual");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblBitacoraElectronicas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TblBitacoraElectronica_catalogoUsuarios");
        });

        modelBuilder.Entity<TblRegistroMensual>(entity =>
        {
            entity.HasKey(e => e.IdReporteMensual);

            entity.ToTable("TblRegistroMensual");

            entity.Property(e => e.AñoReporte).HasColumnName("añoReporte");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaCaptura)
                .HasColumnType("datetime")
                .HasColumnName("fechaCaptura");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.MesReporte).HasColumnName("mesReporte");

            entity.HasOne(d => d.IdLaboratorioNavigation).WithMany(p => p.TblRegistroMensuals)
                .HasForeignKey(d => d.IdLaboratorio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TblRegistroMensual_catalogoLaboratorios");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblRegistroMensuals)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TblRegistroMensual_catalogoUsuarios");
        });

        modelBuilder.Entity<TblRegistroMensualDetalle>(entity =>
        {
            entity.HasKey(e => e.IdReporteMensualAccion).HasName("PK_TblRegistroMensualDetalle_1");

            entity.ToTable("TblRegistroMensualDetalle");

            entity.Property(e => e.AsesoramientoZoosanitarui).HasColumnName("asesoramientoZoosanitarui");
            entity.Property(e => e.CpcBearm).HasColumnName("CPC_Bearm");
            entity.Property(e => e.CpcFlotac).HasColumnName("CPC_Flotac");
            entity.Property(e => e.CpcSedim).HasColumnName("CPC_Sedim");
            entity.Property(e => e.CpsMcm).HasColumnName("CPS_Mcm");
            entity.Property(e => e.DiasGestacion).HasColumnName("diasGestacion");
            entity.Property(e => e.DxScBh).HasColumnName("DX_SC_BH");
            entity.Property(e => e.DxScSc).HasColumnName("DX_SC_SC");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaCaptura)
                .HasColumnType("datetime")
                .HasColumnName("fechaCaptura");
            entity.Property(e => e.FechaReporte)
                .HasColumnType("datetime")
                .HasColumnName("fechaReporte");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Mastitis).HasColumnName("mastitis");
            entity.Property(e => e.ProfilaxisEquina).HasColumnName("profilaxisEquina");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.IdProductorNavigation).WithMany(p => p.TblRegistroMensualDetalles)
                .HasForeignKey(d => d.IdProductor)
                .HasConstraintName("FK_TblRegistroMensualDetalle_catalogoProductores");

            entity.HasOne(d => d.IdReporteMensualNavigation).WithMany(p => p.TblRegistroMensualDetalles)
                .HasForeignKey(d => d.IdReporteMensual)
                .HasConstraintName("FK_TblRegistroMensualDetalle_TblRegistroMensual");
        });

        modelBuilder.Entity<VistaAccionesSeguimiento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaAccionesSeguimiento");

            entity.Property(e => e.AsesoramientoZoosanitarui).HasColumnName("asesoramientoZoosanitarui");
            entity.Property(e => e.AñoReporte).HasColumnName("añoReporte");
            entity.Property(e => e.CpcBearm).HasColumnName("CPC_Bearm");
            entity.Property(e => e.CpcFlotac).HasColumnName("CPC_Flotac");
            entity.Property(e => e.CpcSedim).HasColumnName("CPC_Sedim");
            entity.Property(e => e.CpsMcm).HasColumnName("CPS_Mcm");
            entity.Property(e => e.DiasGestacion).HasColumnName("diasGestacion");
            entity.Property(e => e.DxScBh).HasColumnName("DX_SC_BH");
            entity.Property(e => e.DxScSc).HasColumnName("DX_SC_SC");
            entity.Property(e => e.Expr1).HasColumnType("datetime");
            entity.Property(e => e.Expr2).HasColumnType("datetime");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.FechaCaptura)
                .HasColumnType("datetime")
                .HasColumnName("fechaCaptura");
            entity.Property(e => e.FechaReporte)
                .HasColumnType("datetime")
                .HasColumnName("fechaReporte");
            entity.Property(e => e.Mastitis).HasColumnName("mastitis");
            entity.Property(e => e.MesReporte).HasColumnName("mesReporte");
            entity.Property(e => e.NombreLaboratorio)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombreLaboratorio");
            entity.Property(e => e.NombreProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreProductor");
            entity.Property(e => e.ProfilaxisEquina).HasColumnName("profilaxisEquina");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        modelBuilder.Entity<VistaBitacoraElectronica>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaBitacoraElectronica");

            entity.Property(e => e.ApellidoMaternoProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidoMaternoProductor");
            entity.Property(e => e.ApellidoPaternoProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidoPaternoProductor");
            entity.Property(e => e.AñoReporte).HasColumnName("añoReporte");
            entity.Property(e => e.BitacoraDesparacitacionDesparasitante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bitacoraDesparacitacionDesparasitante");
            entity.Property(e => e.BitacoraDesparacitacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("bitacoraDesparacitacionFecha");
            entity.Property(e => e.BitacoraVacunacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("bitacoraVacunacionFecha");
            entity.Property(e => e.BitacoraVacunacionVacuna)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bitacoraVacunacionVacuna");
            entity.Property(e => e.CasoBitacora)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("casoBitacora");
            entity.Property(e => e.CitaProxima)
                .HasColumnType("datetime")
                .HasColumnName("citaProxima");
            entity.Property(e => e.ClaveUpp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("claveUPP");
            entity.Property(e => e.CoproGastroParasitos).HasColumnName("coproGastroParasitos");
            entity.Property(e => e.CoproGastroPositivos).HasColumnName("coproGastroPositivos");
            entity.Property(e => e.CoproGastroPositivosCoccidias).HasColumnName("coproGastroPositivosCoccidias");
            entity.Property(e => e.CoproMuestras).HasColumnName("coproMuestras");
            entity.Property(e => e.CoproPositivosFasciola).HasColumnName("coproPositivosFasciola");
            entity.Property(e => e.CoproPositivosVerminosis).HasColumnName("coproPositivosVerminosis");
            entity.Property(e => e.FechaActualizacionBitacora)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacionBitacora");
            entity.Property(e => e.FechaActualizacionRegistroMensual)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacionRegistroMensual");
            entity.Property(e => e.FechaBitacora)
                .HasColumnType("datetime")
                .HasColumnName("fechaBitacora");
            entity.Property(e => e.FechaCapturaBitacora)
                .HasColumnType("datetime")
                .HasColumnName("fechaCapturaBitacora");
            entity.Property(e => e.FechaCapturaRegistgroMensual)
                .HasColumnType("datetime")
                .HasColumnName("fechaCapturaRegistgroMensual");
            entity.Property(e => e.FolioBitacora)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("folioBitacora");
            entity.Property(e => e.MedicoResponsable)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("medicoResponsable");
            entity.Property(e => e.MesReporte).HasColumnName("mesReporte");
            entity.Property(e => e.NombreLaboratorio)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombreLaboratorio");
            entity.Property(e => e.NombreProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreProductor");
            entity.Property(e => e.ReproduccionHembras).HasColumnName("reproduccionHembras");
            entity.Property(e => e.ReproduccionHembrasEa).HasColumnName("reproduccionHembrasEA");
            entity.Property(e => e.ReproduccionHembrasGestantes).HasColumnName("reproduccionHembrasGestantes");
            entity.Property(e => e.ReproduccionHembrasIa).HasColumnName("reproduccionHembrasIA");
            entity.Property(e => e.ReproduccionHembrasPalpadas).HasColumnName("reproduccionHembrasPalpadas");
            entity.Property(e => e.ReproduccionHembrasVacias).HasColumnName("reproduccionHembrasVacias");
            entity.Property(e => e.SanguineoAnaplasma).HasColumnName("sanguineoAnaplasma");
            entity.Property(e => e.SanguineoBebesia).HasColumnName("sanguineoBebesia");
            entity.Property(e => e.SanguineoMuestrasBh).HasColumnName("sanguineoMuestrasBH");
            entity.Property(e => e.SanguineoMuestrasHp).HasColumnName("sanguineoMuestrasHP");
            entity.Property(e => e.SanguineoObservaciones)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("sanguineoObservaciones");
            entity.Property(e => e.ServicioPdedental).HasColumnName("servicioPDEDental");
            entity.Property(e => e.ServicioPdelimado).HasColumnName("servicioPDELimado");
            entity.Property(e => e.ServicioPdelobo).HasColumnName("servicioPDELobo");
            entity.Property(e => e.ServicioZooasesoramiento).HasColumnName("servicioZOOAsesoramiento");
            entity.Property(e => e.ServicioZooconsulta).HasColumnName("servicioZOOConsulta");
            entity.Property(e => e.ServicioZoodesparasitación).HasColumnName("servicioZOODesparasitación");
            entity.Property(e => e.ServicioZoootro)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("servicioZOOOtro");
            entity.Property(e => e.ServicioZoovacunación).HasColumnName("servicioZOOVacunación");
            entity.Property(e => e.ServiciosCmt).HasColumnName("serviciosCMT");
            entity.Property(e => e.TrataminetoRocomndado)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("trataminetoRocomndado");
        });

        modelBuilder.Entity<VistaEstrucrturaTerritorial>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaEstrucrturaTerritorial");

            entity.Property(e => e.ClaveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("claveMunicipio");
            entity.Property(e => e.NombreAlcalde)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreAlcalde");
            entity.Property(e => e.NombreDistritoElectoral)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreDistritoElectoral");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRegion");
            entity.Property(e => e.PartidoAlcalde)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("partidoAlcalde");
        });

        modelBuilder.Entity<VistaEvaluacionReproductiva2025Indigena>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaEvaluacionReproductiva2025_Indigena");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.DescripcionApoyo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionApoyo");
            entity.Property(e => e.DescripcionUnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionUnidadMedida");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosAcuacultura>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosAcuacultura");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.DescripcionApoyo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionApoyo");
            entity.Property(e => e.DescripcionUnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionUnidadMedida");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreDistritoElectoral)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreDistritoElectoral");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRegion");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosAcuaculturaAnterior>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosAcuaculturaAnterior");

            entity.Property(e => e.Folio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folio");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosApicultura>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosApicultura");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.DescripcionApoyo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionApoyo");
            entity.Property(e => e.DescripcionUnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionUnidadMedida");
            entity.Property(e => e.Dictamen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dictamen");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Folio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folio");
            entity.Property(e => e.FolioActa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("folioActa");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("localidad");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreDistritoElectoral)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreDistritoElectoral");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("nombreProyecto");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRegion");
            entity.Property(e => e.NombreTipoApoyo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoApoyo");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
            entity.Property(e => e.TelefonoBeneficiario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefonoBeneficiario");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosApicultura2025Indigena>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosApicultura2025_Indigenas");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.DescripcionApoyo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionApoyo");
            entity.Property(e => e.DescripcionUnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionUnidadMedida");
            entity.Property(e => e.Dictamen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dictamen");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Folio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folio");
            entity.Property(e => e.FolioActa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("folioActa");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("localidad");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreProyecto");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRegion");
            entity.Property(e => e.NombreTipoApoyo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoApoyo");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
            entity.Property(e => e.TelefonoBeneficiario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefonoBeneficiario");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosEvaluacionReproductiva>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosEvaluacionReproductiva");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.DescripcionApoyo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionApoyo");
            entity.Property(e => e.DescripcionUnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionUnidadMedida");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosIatf>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosIATF");

            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.FolioSemental)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folioSemental");
            entity.Property(e => e.FolioVientres)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folioVientres");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreDistritoElectoral)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreDistritoElectoral");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("nombreProyecto");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRegion");
            entity.Property(e => e.NumeroEntrega1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numeroEntrega1");
            entity.Property(e => e.NumeroEntrega2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numeroEntrega2");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.Sementales).HasColumnName("sementales");
            entity.Property(e => e.Vientres).HasColumnName("vientres");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosIfpaptev>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosIFPAPTEV");

            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Folio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folio");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("localidad");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("nombreProyecto");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRegion");
            entity.Property(e => e.NombreTipoApoyo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoApoyo");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.TelefonoBeneficiario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefonoBeneficiario");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosServicioInseminacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosServicioInseminacion");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.DescripcionApoyo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionApoyo");
            entity.Property(e => e.DescripcionUnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionUnidadMedida");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
        });

        modelBuilder.Entity<VistaPadronBeneficiariosUbicacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronBeneficiariosUbicacion");

            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("localidad");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("nombreProyecto");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRegion");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
        });

        modelBuilder.Entity<VistaPadronIfpaptev2025Indigena>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronIFPAPTEV2025_Indigena");

            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Folio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("folio");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("localidad");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreProyecto");
            entity.Property(e => e.NombreTipoApoyo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoApoyo");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.TelefonoBeneficiario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefonoBeneficiario");
        });

        modelBuilder.Entity<VistaPadronProductoresUpp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPadronProductoresUPP");

            entity.Property(e => e.ApellidoMaternoProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidoMaternoProductor");
            entity.Property(e => e.ApellidoPaternoProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidoPaternoProductor");
            entity.Property(e => e.ClaveUpp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("claveUPP");
            entity.Property(e => e.CorreoProductor)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("correoProductor");
            entity.Property(e => e.CurpProductor)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("curpProductor");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.EspecieRegistadaBovino).HasColumnName("especieRegistadaBovino");
            entity.Property(e => e.EspecieRegistadaEquino).HasColumnName("especieRegistadaEquino");
            entity.Property(e => e.EspecieRegistadaOvino).HasColumnName("especieRegistadaOvino");
            entity.Property(e => e.EspecieRegistadaPorcino).HasColumnName("especieRegistadaPorcino");
            entity.Property(e => e.EspecieTrabajadaBovino).HasColumnName("especieTrabajadaBovino");
            entity.Property(e => e.EspecieTrabajadaEquino).HasColumnName("especieTrabajadaEquino");
            entity.Property(e => e.EspecieTrabajadaOvino).HasColumnName("especieTrabajadaOvino");
            entity.Property(e => e.EspecieTrabajadaPorcino).HasColumnName("especieTrabajadaPorcino");
            entity.Property(e => e.GeneroProductor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("generoProductor");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreProductor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreProductor");
            entity.Property(e => e.NombreUpp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreUPP");
            entity.Property(e => e.TelefonoProductor)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefonoProductor");
            entity.Property(e => e.TotalHato).HasColumnName("totalHato");
            entity.Property(e => e.TotalProbados).HasColumnName("totalProbados");
        });

        modelBuilder.Entity<VistaPyhonBeneficiariosResuman>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPyhonBeneficiariosResumen");

            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreProyectoCorto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreProyectoCorto");
            entity.Property(e => e.TotalBeneficiarios).HasColumnName("totalBeneficiarios");
        });

        modelBuilder.Entity<VistaPythonBeneficiariosMunicipioResuman>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPythonBeneficiariosMunicipioResumen");

            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.NombreProyectoCorto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreProyectoCorto");
            entity.Property(e => e.TotalBeneficiarios).HasColumnName("totalBeneficiarios");
        });

        modelBuilder.Entity<VistaServiciosInseminacion2025Indigena>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaServiciosInseminacion2025_Indigena");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CveLocalidad)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cveLocalidad");
            entity.Property(e => e.CveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cveMunicipio");
            entity.Property(e => e.DescripcionApoyo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionApoyo");
            entity.Property(e => e.DescripcionUnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionUnidadMedida");
            entity.Property(e => e.IdProyecto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.NombreBeneficiarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreBeneficiarios");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombreLocalidad");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombreMunicipio");
            entity.Property(e => e.PeriodoPadron).HasColumnName("periodoPadron");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
