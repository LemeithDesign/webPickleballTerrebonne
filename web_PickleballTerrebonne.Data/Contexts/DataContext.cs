using Microsoft.EntityFrameworkCore;
using web_PickleballTerrebonne.Data.Entites;

namespace web_PickleballTerrebonne.Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Inscription> Inscriptions { get; set; }
    }
}