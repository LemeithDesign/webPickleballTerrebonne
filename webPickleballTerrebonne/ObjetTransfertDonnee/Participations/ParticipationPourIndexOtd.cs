using System.Data.Common;

namespace webPickleballTerrebonne.ObjetTransfertDonnee.Participations
{
    public class ParticipationPourIndexOtd
    {
        public int IdParticipation { get; set; }
        public DateTime DateParticipation { get; set; }
        public TimeOnly HeureDebut { get; set; }
        public DayOfWeek Jour { get { return DateParticipation.DayOfWeek; } }
        public string Terrain { get; set; } = string.Empty;
    }
}
