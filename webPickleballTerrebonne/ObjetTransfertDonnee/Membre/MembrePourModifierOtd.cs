using System.ComponentModel.DataAnnotations;

namespace webPickleballTerrebonne.ObjetTransfertDonnee.Membre
{
    public class MembrePourModifierOtd
    {
        public int Id { get; set; }

        [Display(Name = "Numéro de membre")]
        public int NoMembre { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(100, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(100, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string Prenom { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone mobile (cellulaire)")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(12, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string TelephoneMobile { get; set; } = string.Empty;

        [Display(Name = "Numéro civique et nom de la rue")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(100, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string Adresse { get; set; } = string.Empty;

        [Display(Name = "Appartement")]
        [StringLength(10, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string? Appartement { get; set; } = null;

        [Display(Name = "Ville")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(50, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string Ville { get; set; } = string.Empty;

        [Display(Name = "Code postal")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(7, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string CodePostal { get; set; } = string.Empty;


        // Contact d'urgence
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(100, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string ContactUrgenceNom { get; set; } = string.Empty;

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(100, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string ContactUrgencePrenom { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone mobile (cellulaire)")]
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [StringLength(12, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string ContactUrgenceTelephone { get; set; } = string.Empty;

        [Display(Name = "Relation avec le joueur")]
        [StringLength(100, ErrorMessage = "Le champ {0} doit avoir au maximum {1} caractères.")]
        public string? ContactUrgenceRelation { get; set; } = null;
    }
}