using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webPickleballTerrebonne.Data.Entites
{
    public class PlageHoraire
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlageHoraire { get; set; }
        public DayOfWeek Jour { get; set; }
        public TimeOnly HeureDebut { get; set; }
        public TimeOnly HeureFin { get; set; }

        public int QtePlaceMaximale { get; set; }
        public int QtePlaceOptimale { get; set; }

        public int TerrainId { get; set; }
        public virtual Terrain Terrain { get; set; } = default!;

        public int ResponsableId { get; set; }
        public virtual Membre Responsable { get; set; } = default!;

        public List<Membre> MembresReguliers { get; set; } = [];

        public List<Participation> Participations { get; set; } = [];
    }
}
