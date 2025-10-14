using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webPickleballTerrebonne.Data.Entites
{
    public class Inscription
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Prenom { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Nom { get; set; } = string.Empty;

        [Required, StringLength(12)]
        public string Telephone { get; set; } = string.Empty;

        [Required, StringLength(200), EmailAddress]
        public string Courriel { get; set; } = string.Empty;

        [Required]
        public DateOnly DateNaissance { get; set; }

        [Required, StringLength(200)]
        public string Adresse { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Ville { get; set; } = string.Empty;

        [Required, StringLength(10)]
        public string CodePostal { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string PrenomContactUrgence { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string NomContactUrgence { get; set; } = string.Empty;


        [Required, StringLength(12)]
        public string TelephoneContactUrgence { get; set; } = string.Empty;
    }
}
