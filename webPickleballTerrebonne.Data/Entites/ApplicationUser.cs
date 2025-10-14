using Microsoft.AspNetCore.Identity;

namespace webPickleballTerrebonne.Data.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public int MembreId { get; set; }
        public virtual Membre Membre { get; set; } = default!;
    }
}