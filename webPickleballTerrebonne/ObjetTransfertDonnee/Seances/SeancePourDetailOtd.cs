namespace webPickleballTerrebonne.ObjetTransfertDonnee.Seances
{
    public class SeancePourDetailOtd
    {
        public int IdSeance { get; set; }
        public DayOfWeek Jour { get; set; }
        public string HeureDebut { get; set; } = string.Empty;
        public string HeureFin { get; set; } = string.Empty;

        public int QtePlaceMaximale { get; set; }
        public int QtePlaceOptimale { get; set; }

        // Terrain
        public string NomTerrain { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;

        // Responbable
        public string NomResponsable { get; set; } = string.Empty;

    }
}