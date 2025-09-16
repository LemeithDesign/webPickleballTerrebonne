using web_PickleballTerrebonne.Data.Enum;

namespace web_PickleballTerrebonne.Data.Entites
{
    public class EntreeListeAttente
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public StatutAttente Statut { get; set; } // "EnAttente", "EnCours", "Terminé"

    }
}