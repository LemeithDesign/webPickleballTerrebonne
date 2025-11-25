using System.ComponentModel.DataAnnotations;

namespace webPickleballTerrebonne.ObjetTransfertDonnee.Membre
{
    public class MembrePourCreerOtd
    {
        [Display(Name = "Adresse courriel")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [EmailAddress(ErrorMessage = "Format d'adresse courriel invalide.")]
        [StringLength(255, ErrorMessage = "Le champ {0} ne doit pas dépasser {1} caractères.")]
        public string Courriel { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit avoir au moins {2} et au maximum {1} caractères.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmation du mot de passe")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = string.Empty;

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


        public string? Role { get; set; } = null;
    }
}