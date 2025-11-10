using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Membre> Membres { get; set; }
        //public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Terrain> Terrains { get; set; }
        public DbSet<PlageHoraire> PlagesHoraires { get; set; }
        public DbSet<Participation> Participations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Membre>()
                .HasOne(m => m.ApplicationUser)
                .WithOne(u => u.Membre)
                .HasForeignKey<ApplicationUser>(m => m.MembreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}