using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Data
{
    public class ServiceAutoContext : DbContext
    {
        public ServiceAutoContext(DbContextOptions<ServiceAutoContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Masina> Masini { get; set; }
        public DbSet<Mecanic> Mecanici { get; set; }
        public DbSet<PiesaDeSchimb> PieseDeSchimb { get; set; }
        public DbSet<Interventie> Interventii { get; set; }
        public DbSet<InterventiePiesa> InterventiiPiese { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InterventiePiesa>()
                .HasKey(ip => new { ip.InterventieId, ip.PiesaDeSchimbId });

            modelBuilder.Entity<InterventiePiesa>()
                .HasOne(ip => ip.Interventie)
                .WithMany(i => i.InterventiiPiese)
                .HasForeignKey(ip => ip.InterventieId);

            modelBuilder.Entity<InterventiePiesa>()
                .HasOne(ip => ip.PiesaDeSchimb)
                .WithMany(p => p.InterventiiPiese)
                .HasForeignKey(ip => ip.PiesaDeSchimbId);
        }
    }
}
