using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using web_PickleballTerrebonne.Data.Entites;

namespace web_PickleballTerrebonne.Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Membre> Membres { get; set; }
        //public DbSet<Inscription> Inscriptions { get; set; }

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