using System.ComponentModel.DataAnnotations;

namespace web_PickleballTerrebonne.ObjetTransfertDonnee.Inscription
{
    public class InscriptionPourCreerOtd
    {
        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas avoir plus de 100 caractères.")]
        public string Prenom { get; set; } = string.Empty;

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas avoir plus de 100 caractères.")]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone")]
        [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
        [StringLength(12, ErrorMessage = "Le numéro de téléphone ne peut pas avoir plus de 12 caractères.")]
        public string Telephone { get; set; } = string.Empty;

        [Display(Name = "Adresse courriel")]
        [Required(ErrorMessage = "L'adresse courriel est requise.")]
        [StringLength(200, ErrorMessage = "L'adresse courriel ne peut pas avoir plus de 200 caractères.")]
        [EmailAddress(ErrorMessage = "L'adresse entrée est invalide. SVP, corriger.")]
        public string Courriel { get; set; } = string.Empty;

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "La date de naissance est requise.")]
        public DateOnly DateNaissance { get; set; }

        [Display(Name = "No civique et rue")]
        [Required(ErrorMessage = "L'adresse est requise.")]
        [StringLength(200, ErrorMessage = "L'adresse ne peut pas avoir plus de 200 caractères.")]
        public string Adresse { get; set; } = string.Empty;

        [Display(Name = "Ville")]
        [Required(ErrorMessage = "Le nom de la ville est requis.")]
        [StringLength(100, ErrorMessage = "Le nom de la ville ne peut pas avoir plus de 100 caractères.")]
        public string Ville { get; set; } = string.Empty;

        [Display(Name = "Code postal")]
        [Required(ErrorMessage = "Le code postal est requis.")]
        [StringLength(10, ErrorMessage = "Le code postal ne peut pas avoir plus de 10 caractères.")]
        public string CodePostal { get; set; } = string.Empty;


        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le prénom d'un contact d'urgence est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom d'un contact d'urgence ne peut pas avoir plus de 100 caractères.")]
        public string PrenomContactUrgence { get; set; } = string.Empty;

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom d'un contact d'urgence est requis.")]
        [StringLength(100, ErrorMessage = "Le nom d'un contact d'urgence ne peut pas avoir plus de 100 caractères.")]
        public string NomContactUrgence { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone")]
        [Required(ErrorMessage = "Le numéro de téléphone d'un contact d'urgence est requis.")]
        [StringLength(12, ErrorMessage = "Le numéro de téléphone d'un contact d'urgence ne peut pas avoir plus de 12 caractères.")]
        public string TelephoneContactUrgence { get; set; } = string.Empty;
    }
}