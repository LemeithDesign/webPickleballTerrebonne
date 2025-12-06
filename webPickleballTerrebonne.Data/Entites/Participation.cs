using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webPickleballTerrebonne.Data.Entites
{
    public class Participation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParticipation { get; set; }

        public DateTime DateParticipation { get; set; }

        public int IdPlageHoraire { get; set; }
        public virtual PlageHoraire PlageHoraire { get; set; } = default!;

        public List<Membre> Participants { get; set; } = [];    
    }
}