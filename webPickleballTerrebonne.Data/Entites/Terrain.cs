namespace webPickleballTerrebonne.Data.Entites
{
    public class Terrain
    {
        public int IdTerrain { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Adresse { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;


        //public ICollection<Seance> Seances { get; set; } = new List<Seance>();
    }
}
