using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webPickleballTerrebonne.Data.Entites
{
    public class Terrain
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTerrain { get; set; }

        [Required, StringLength(100)]
        public string Nom { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }

        [Required, StringLength(100)]
        public string Adresse { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string Ville { get; set; } = string.Empty;

        [Required, StringLength(7)]
        public string CodePostal { get; set; } = string.Empty;
    }
}
