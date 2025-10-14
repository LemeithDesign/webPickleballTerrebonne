namespace webPickleballTerrebonne.ObjetTransfertDonnee.Inscription
{
    public class InscriptionPourDetailsOtd
    {
        public int Id { get; set; }
        public string Prenom { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Courriel { get; set; } = string.Empty;
        public DateOnly DateNaissance { get; set; }
        public string Adresse { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string PrenomContactUrgence { get; set; } = string.Empty;
        public string NomContactUrgence { get; set; } = string.Empty;
        public string TelephoneContactUrgence { get; set; } = string.Empty;
    }
}