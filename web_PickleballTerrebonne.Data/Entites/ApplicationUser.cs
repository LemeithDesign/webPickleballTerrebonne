using Microsoft.AspNetCore.Identity;

namespace web_PickleballTerrebonne.Data.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public int MembreId { get; set; }
        public virtual Membre Membre { get; set; }
    }
}