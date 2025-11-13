namespace webPickleballTerrebonne.ObjetTransfertDonnee.Membre
{
    public class MembrePourIndexOtd
    {
        public int Id { get; set; }

        public int NoMembre { get; set; }

        //[Required, StringLength(100)]
        public string Nom { get; set; } = string.Empty;

        //[Required, StringLength(100)]
        public string Prenom { get; set; } = string.Empty;

    }
}