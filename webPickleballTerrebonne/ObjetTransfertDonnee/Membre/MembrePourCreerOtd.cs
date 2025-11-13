using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.ObjetTransfertDonnee.Membre
{
    public class MembrePourCreerOtd
    {
        public int NoMembre { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(100, ErrorMessage = "Le numéro de téléphone mobile (cellulaire)nom doit avoir au maximum 12 caractères.")]

        public string Nom { get; set; } = string.Empty;

        [Required, StringLength(100)]


        public string Prenom { get; set; } = string.Empty;

        //public string AppUserId { get; set; } = string.Empty;
        //public virtual ApplicationUser ApplicationUser { get; set; } = default!;

        [Required(ErrorMessage = "Le numéro de téléphone mobile (cellulaire) est requis.")]
        [StringLength(12,ErrorMessage = "Le numéro de téléphone mobile (cellulaire) doit avoir au maximum 12 caractères.")]
        public string TelephoneMobile { get; set; } = string.Empty;

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