namespace webPickleballTerrebonne.ObjetTransfertDonnee.Seances
{
    public class SeancePourIndexOtd
    {
        public int IdSeance { get; set; }
        public DayOfWeek Jour { get; set; }
        public string HeureDebut { get; set; } = string.Empty;
        public string NomTerrain { get; set; } = string.Empty;
    }
}