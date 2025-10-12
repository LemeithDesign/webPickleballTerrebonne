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

        [StringLength(12)]
        public string? TelephoneMobile { get; set; }


        [Required, StringLength(100)]
        public string Adresse { get; set; } = string.Empty;


        [StringLength(10)]
        public string? Appartement { get; set; } = string.Empty;


        [Required, StringLength(50)]
        public string Ville { get; set; } = string.Empty;

        [Required, StringLength(7)]
        public string CodePostal { get; set; } = string.Empty;


        // Contact d'urgence
        [Required, StringLength(100)]
        public string ContactUrgence { get; set; } = string.Empty;
        [Required, StringLength(12)]
        public string ContactUrgenceTelephone { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string ContactUrgenceRelation { get; set; } = string.Empty;
    }
}