using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_PickleballTerrebonne.Data.Entites
{
    public class Membre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NoMembre { get; set; }

        public string AppUserId { get; set; } = string.Empty;
        public virtual ApplicationUser ApplicationUser { get; set; } = default!;


        [Required, StringLength(100)]
        public string Nom { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Prenom { get; set; } = string.Empty;
    }
}