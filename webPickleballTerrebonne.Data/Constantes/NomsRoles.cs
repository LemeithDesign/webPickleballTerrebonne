namespace webPickleballTerrebonne.Data.Constantes
{
    public static class NomsRoles
    {
        public const string Admin = "Admin";
        public const string CA = "CA";
        public const string Membre = "Membre";
        public const string User = "User";

        public static readonly List<string> Roles =
        [
            Admin,
            CA,
            Membre,
            User
        ];
    }
}