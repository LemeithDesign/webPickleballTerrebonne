using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webPickleballTerrebonne.Data.Entites
{
    public class Participation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParticipation { get; set; }

        public int IdSeance { get; set; }
        public virtual PlageHoraire PlageHoraire { get; set; } = default!;

        public int IdMembre { get; set; }
        public virtual Membre Membre { get; set; } = default!;

        public bool? EstPresent { get; set; }
    }
}