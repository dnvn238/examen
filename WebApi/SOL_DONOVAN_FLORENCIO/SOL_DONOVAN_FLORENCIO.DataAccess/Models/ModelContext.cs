using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SOL_DONOVAN_FLORENCIO.DataAccess.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("UPC")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Idlibro);

                entity.ToTable("LIBRO");

                entity.Property(e => e.Idlibro)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDLIBRO");

                entity.Property(e => e.Autor)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("AUTOR");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIA");

                entity.Property(e => e.Editorial)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EDITORIAL");

                entity.Property(e => e.Fechapublicacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAPUBLICACION")
                    .HasDefaultValueSql("sysdate ");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Pais)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("PAIS");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.Idprestamo);

                entity.ToTable("PRESTAMO");

                entity.Property(e => e.Idprestamo)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPRESTAMO");

                entity.Property(e => e.Fechadevolucion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHADEVOLUCION")
                    .HasDefaultValueSql("sysdate ");

                entity.Property(e => e.Fechaprestamo)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAPRESTAMO")
                    .HasDefaultValueSql("sysdate ");

                entity.Property(e => e.Idlibro)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDLIBRO");

                entity.Property(e => e.Idusuario)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDUSUARIO");

                entity.Property(e => e.Tipolectura)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TIPOLECTURA");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.Idlibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRESTAMO_LIBRO");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRESTAMO_USUARIO");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("USUARIO");

                entity.Property(e => e.Idusuario)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDUSUARIO");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Dni)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Estado)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ESTADO");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.Tipousuario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TIPOUSUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
