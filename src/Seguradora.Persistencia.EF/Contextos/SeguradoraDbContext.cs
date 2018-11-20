using Microsoft.EntityFrameworkCore;
using Seguradora.Dominio.Models.Segurados;
using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Persistencia.EF.Contextos
{
    public class SeguradoraDbContext : DbContext
    {
        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Residencia> Residencias { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Vida> Vida { get; set; }

        public SeguradoraDbContext(DbContextOptions<SeguradoraDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Seguro>().ToTable("Seguros");
            builder.Entity<Seguro>().HasKey(p => p.Id);
            builder.Entity<Seguro>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Seguro>().Property(p => p.CpfCnpj).IsRequired().HasMaxLength(14);
            builder.Entity<Seguro>().Property(p => p.SeguroSeguradoId).IsRequired();
            builder.Entity<Seguro>().HasOne(p => p.SeguroSegurado)
                                    .WithOne(p => p.Seguro)
                                    .HasForeignKey<Seguro>(p => p.SeguroSeguradoId);

            builder.Entity<SeguroSegurado>().ToTable("SeguroSegurado");
            builder.Entity<SeguroSegurado>().HasKey(p => p.Id);
            builder.Entity<SeguroSegurado>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SeguroSegurado>().Property(p => p.SeguroId).IsRequired();
            builder.Entity<SeguroSegurado>().Property(p => p.VeiculoId);
            builder.Entity<SeguroSegurado>().Property(p => p.VidaId);
            builder.Entity<SeguroSegurado>().Property(p => p.ResidenciaId);
            builder.Entity<SeguroSegurado>().HasOne(p => p.Veiculo)
                .WithOne(p => p.SeguroSegurado)
                .HasForeignKey<SeguroSegurado>(p => p.VeiculoId);
            builder.Entity<SeguroSegurado>().HasOne(p => p.Residencia)
                .WithOne(p => p.SeguroSegurado)
                .HasForeignKey<SeguroSegurado>(p => p.ResidenciaId);
            builder.Entity<SeguroSegurado>().HasOne(p => p.Vida)
                .WithOne(p => p.SeguroSegurado)
                .HasForeignKey<SeguroSegurado>(p => p.VidaId);

            builder.Entity<Residencia>().ToTable("Residencias");
            builder.Entity<Residencia>().HasKey(r => r.Id);
            builder.Entity<Residencia>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Residencia>().Property(r => r.Rua).IsRequired().HasMaxLength(100);
            builder.Entity<Residencia>().Property(r => r.Numero);
            builder.Entity<Residencia>().Property(r => r.Bairro).IsRequired().HasMaxLength(100);
            builder.Entity<Residencia>().Property(r => r.Cidade).IsRequired().HasMaxLength(100);

            builder.Entity<Veiculo>().ToTable("Veiculos");
            builder.Entity<Veiculo>().HasKey(v => v.Id);
            builder.Entity<Veiculo>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Veiculo>().Property(v => v.Placa).IsRequired().HasMaxLength(7);

            builder.Entity<Vida>().ToTable("Vidas");
            builder.Entity<Vida>().HasKey(v => v.Id);
            builder.Entity<Vida>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Vida>().Property(v => v.Cpf).IsRequired().HasMaxLength(11);
        }
    }
}