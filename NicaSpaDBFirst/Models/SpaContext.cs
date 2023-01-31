using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NicaSpaDBFirst.Models;

public partial class SpaContext : DbContext
{
    public SpaContext()
    {
    }

    public SpaContext(DbContextOptions<SpaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendarioterapistum> Calendarioterapista { get; set; }

    public virtual DbSet<Horariostratamiento> Horariostratamientos { get; set; }

    public virtual DbSet<Masajistum> Masajista { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<Tipousuario> Tipousuarios { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendarioterapistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CALENDAR__3214EC277AF5644D");

            entity.ToTable("CALENDARIOTERAPISTA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Idhorario).HasColumnName("IDHORARIO");
            entity.Property(e => e.Idmasajista).HasColumnName("IDMASAJISTA");

            entity.HasOne(d => d.IdhorarioNavigation).WithMany(p => p.Calendarioterapista)
                .HasForeignKey(d => d.Idhorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CALENDARI__IDHOR__300424B4");

            entity.HasOne(d => d.IdmasajistaNavigation).WithMany(p => p.Calendarioterapista)
                .HasForeignKey(d => d.Idmasajista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CALENDARI__IDMAS__2F10007B");
        });

        modelBuilder.Entity<Horariostratamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HORARIOS__3214EC27BB14FFD7");

            entity.ToTable("HORARIOSTRATAMIENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Horario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HORARIO");
        });

        modelBuilder.Entity<Masajistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MASAJIST__3214EC27AFF79CFD");

            entity.ToTable("MASAJISTA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("IMAGEN");
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.Idreservacion).HasName("PK__RESERVAC__E18E99FBB05EACD0");

            entity.ToTable("RESERVACION");

            entity.Property(e => e.Idreservacion).HasColumnName("IDRESERVACION");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Idmasajista).HasColumnName("IDMASAJISTA");
            entity.Property(e => e.Idtratamiento).HasColumnName("IDTRATAMIENTO");
            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");
            entity.Property(e => e.Masajista)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MASAJISTA");
            entity.Property(e => e.Total).HasColumnName("TOTAL");
            entity.Property(e => e.Tratamiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TRATAMIENTO");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.IdmasajistaNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.Idmasajista)
                .HasConstraintName("FK__RESERVACI__IDMAS__34C8D9D1");

            entity.HasOne(d => d.IdtratamientoNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.Idtratamiento)
                .HasConstraintName("FK__RESERVACI__IDTRA__33D4B598");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__RESERVACI__IDUSU__32E0915F");
        });

        modelBuilder.Entity<Tipousuario>(entity =>
        {
            entity.HasKey(e => e.Codigotipousuario).HasName("PK__TIPOUSUA__ECE2CF389C0D9383");

            entity.ToTable("TIPOUSUARIO");

            entity.Property(e => e.Codigotipousuario).HasColumnName("CODIGOTIPOUSUARIO");
            entity.Property(e => e.Tipousuario1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TIPOUSUARIO");
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TRATAMIE__3214EC277EF3CA05");

            entity.ToTable("TRATAMIENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("IMAGEN");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Codigousuario).HasName("PK__USUARIO__B6D90A2A578D82F8");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Codigousuario).HasColumnName("CODIGOUSUARIO");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Codigotipousuario).HasColumnName("CODIGOTIPOUSUARIO");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRASEÑA");
            entity.Property(e => e.Imagenusuario)
                .IsUnicode(false)
                .HasColumnName("IMAGENUSUARIO");
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");

            entity.HasOne(d => d.CodigotipousuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Codigotipousuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIO__CODIGOT__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
