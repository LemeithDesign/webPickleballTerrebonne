using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webPickleballTerrebonne.Data.Entites
{
    public class Membre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AppUserId { get; set; } = string.Empty;
        public virtual ApplicationUser ApplicationUser { get; set; } = default!;

        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime? DateMembreActif { get; set; } = null;
        public DateTime? DateMembreInactif { get; set; } = DateTime.Now;

        public string MembreActif
        {
            get
            {
                if(ApplicationUser is null)
                    return "Inconnu";

                if (ApplicationUser.MembreActif)
                    return "Actif";
                else
                    return "Inactif";
            }
        }

        // Identification
        public int NoMembre { get; set; }

        [Required, StringLength(100)]
        public string Nom { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string Prenom { get; set; } = string.Empty;
        [StringLength(12)]
        public string? TelephoneMobile { get; set; }

        // Adresse
        [Required, StringLength(100)]
        public string Adresse { get; set; } = string.Empty;

        [StringLength(10)]
        public string? Appartement { get; set; } = null;

        [Required, StringLength(50)]
        public string Ville { get; set; } = string.Empty;

        [Required, StringLength(7)]
        public string CodePostal { get; set; } = string.Empty;


        // Contact d'urgence
        [Required, StringLength(100)]
        public string ContactUrgenceNom { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string ContactUrgencePrenom { get; set; } = string.Empty;
        [Required, StringLength(12)]
        public string ContactUrgenceTelephone { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string? ContactUrgenceRelation { get; set; } = null;

        public List<Participation> Participations { get; set; } = [];
    }
}