 using Microsoft.EntityFrameworkCore;
using ProJur.Domain.Application.Entities;

namespace ProJur.Domain.Infra.Context
{
    public class ProjurContext : DbContext
    {
        public ProjurContext(DbContextOptions<ProjurContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(x => x.Sobrenome).HasMaxLength(160).HasColumnType("varchar(160)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(x => x.DataNascimento).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Usuario>().Property(x => x.Escolaridade).HasColumnType("int").IsRequired();
        }
    }
}