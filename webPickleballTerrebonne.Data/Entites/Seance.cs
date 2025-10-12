using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_PickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Data.Entites
{
    public class Seance
    {
        public int IdSeance { get; set; }
        DayOfWeek Jour { get; set; }
        TimeOnly HeureDebut { get; set; }
        TimeOnly heureFin { get; set; }

        public int QtePlaceMaximale { get; set; }
        public int QtePlaceChoisi { get; set; }

        public int TerrainId { get; set; }
        public Terrain Terrain { get; set; } = default!;

        public int ResponsableId { get; set; }
        public Membre Responsable { get; set; } = default!;

        //public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
