using System.ComponentModel.DataAnnotations;

namespace webPickleballTerrebonne.ObjetTransfertDonnee.Membre
{
    public class MembrePourDetailsOtd
    {
        public int Id { get; set; }

        [Display(Name = "Numéro de membre")]
        public int NoMembre { get; set; }
        public string MembreActif { get; set; } = string.Empty;
        public DateTime? DateMembreActif { get; set; } = null;
        public DateTime? DateMembreInactif { get; set; } = null;


        // Identification
        [Display(Name = "Adresse courriel")]
        public string Courriel { get; set; } = string.Empty;

        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Prénom")]
        public string Prenom { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone mobile (cellulaire)")]
        public string TelephoneMobile { get; set; } = string.Empty;

        // Adresse
        [Display(Name = "Numéro civique et nom de la rue")]
        public string Adresse { get; set; } = string.Empty;

        [Display(Name = "Appartement")]
        public string? Appartement { get; set; } = null;

        [Display(Name = "Ville")]
        public string Ville { get; set; } = string.Empty;

        [Display(Name = "Code postal")]
        public string CodePostal { get; set; } = string.Empty;


        // Contact d'urgence
        [Display(Name = "Nom")]
        public string ContactUrgenceNom { get; set; } = string.Empty;

        [Display(Name = "Prénom")]
        public string ContactUrgencePrenom { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone mobile (cellulaire)")]
        public string ContactUrgenceTelephone { get; set; } = string.Empty;

        [Display(Name = "Relation avec le joueur")]
        public string? ContactUrgenceRelation { get; set; } = null;
    }
}