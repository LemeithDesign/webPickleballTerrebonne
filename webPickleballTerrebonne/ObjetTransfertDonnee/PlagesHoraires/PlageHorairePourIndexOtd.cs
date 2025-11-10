namespace webPickleballTerrebonne.ObjetTransfertDonnee.PlagesHoraires
{
    public class PlageHorairePourIndexOtd
    {
        public int IdPlageHoraire { get; set; }
        public DayOfWeek Jour { get; set; }
        public string HeureDebut { get; set; } = string.Empty;
        public string NomTerrain { get; set; } = string.Empty;
    }
}