using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webPickleballTerrebonne.Data.Contexts;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Data.Initializer
{
    public class DbInitializer(IMembreData gestMembre, IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager)
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IUserStore<ApplicationUser> _userStore = userStore;
        private readonly IMembreData _gestMembre = gestMembre;

        public async Task Seed(DataContext context)
        {

            // Ajouter des membres et des utilisateurs par défaut si la table Users est vide.
            if (!context.Users.Any())
            {
                Membre membreFS = new()
                {
                    Prenom = "Félix",
                    Nom = "Séguin",
                    NoMembre = 576,
                    TelephoneMobile = "514-706-5848",
                    Adresse = "1045 rue de Louvigny",
                    Ville = "Terrebonne",
                    CodePostal = "J6X 1X2",
                    ContactUrgence = "Isabelle Passarelli",
                    ContactUrgenceTelephone = "514-609-5409",
                    ContactUrgenceRelation = "Conjointe"
                };
                int idMembreFS = await _gestMembre.CreerMembreAsync(membreFS);

                // Créer un appUser:

                ApplicationUser userFS = Activator.CreateInstance<ApplicationUser>();


                await _userStore.SetUserNameAsync(userFS, "felix.a.seguin@gmail.com", CancellationToken.None);

                userFS.Membre = membreFS;
                userFS.MembreId = idMembreFS;
                userFS.EmailConfirmed = true;

                var resultFS = await _userManager.CreateAsync(userFS, "IsaKaf16@");


                Membre membreIP = new()
                {
                    Prenom = "Isabelle",
                    Nom = "Passarelli",
                    NoMembre = 577,
                    TelephoneMobile = "514-609-5409",
                    Adresse = "1045 rue de Louvigny",
                    Ville = "Terrebonne",
                    CodePostal = "J6X 1X2",
                    ContactUrgence = "Félix Séguin",
                    ContactUrgenceTelephone = "514-706-5848",
                    ContactUrgenceRelation = "Conjoint"
                };
                int idMembreIP = await _gestMembre.CreerMembreAsync(membreIP);

                // Créer un appUser:

                ApplicationUser userIP = Activator.CreateInstance<ApplicationUser>();


                await _userStore.SetUserNameAsync(userIP, "isabelle.l.passarelli@gmail.com", CancellationToken.None);

                userIP.Membre = membreIP;
                userIP.MembreId = idMembreIP;
                userIP.EmailConfirmed = true;

                var resultIP = await _userManager.CreateAsync(userIP, "IsaKaf16@");

            }


            if(!context.Terrains.Any())
            {
                Terrain terrain1 = new()
                {
                    Nom = "École des Explorateurs",
                    Description = "Terrain intérieur avec 4 terrains de pickleball. Stationnement disponible.",
                    Adresse = "1185 Boulevard des Plateaux",
                    Ville = "Terrebonne",
                    CodePostal = "J6Y 0E7"
                };
                Terrain terrain2 = new()
                {
                    Nom = "École des Pionniers",
                    Description = "Terrain intérieur avec 2 terrains de pickleball. Stationnement disponible.",
                    Adresse = "1241 Avenue de la Croisée",
                    Ville = "Terrebonne",
                    CodePostal = "J6V 0H6"
                };
                Terrain terrain3 = new()
                {
                    Nom = "École Espace-Couleurs",
                    Description = "Terrain intérieur avec 2 terrains de pickleball. Stationnement disponible.",
                    Adresse = "1000 Rue Marie-Gérin-Lajoie",
                    Ville = "Terrebonne",
                    CodePostal = "J6Y 0M1"
                };
                Terrain terrain4 = new()
                {
                    Nom = "École Le Castelet",
                    Description = "Terrain intérieur avec 2 terrains de pickleball. Stationnement disponible.",
                    Adresse = "4200 Rue Robert",
                    Ville = "Terrebonne",
                    CodePostal = "J6X 2N9"
                };
                Terrain terrain5 = new()
                {
                    Nom = "École Marie-Soleil Tougas",
                    Description = "Terrain intérieur avec 2 terrains de pickleball. Stationnement disponible.",
                    Adresse = "3415 Place Camus",
                    Ville = "Terrebonne",
                    CodePostal = "J6Y 1L2"
                };
                Terrain terrain6 = new()
                {
                    Nom = "École du Boisé",
                    Description = "Terrain intérieur avec 2 terrains de pickleball. Stationnement disponible.",
                    Adresse = "5900 Rue Rodrigue",
                    Ville = "Terrebonne",
                    CodePostal = "J7M 1Y6"
                };
                Terrain terrain7 = new()
                {
                    Nom = "École Esther Blondin",
                    Description = "Terrain intérieur avec 2 terrains de pickleball. Stationnement disponible.",
                    Adresse = "905 Rue Vaillant",
                    Ville = "Terrebonne",
                    CodePostal = "J6X 1N1"
                };
                Terrain terrain8 = new()
                {
                    Nom = "École La Sablière",
                    Description = "Terrain intérieur avec 2 terrains de pickleball. Stationnement disponible.",
                    Adresse = "1659 Bd des Seigneurs",
                    Ville = "Terrebonne",
                    CodePostal = "J6X 4T1"
                };

                await context.Terrains.AddRangeAsync(
                    terrain1, 
                    terrain2,
                    terrain3,
                    terrain4,
                    terrain5,
                    terrain6,
                    terrain7,
                    terrain8
                    );
                await context.SaveChangesAsync();
            }


            if(!context.Seances.Any())
            {
                // Mercredi
                Terrain terrain8 = context.Terrains.FirstOrDefault(t => t.Nom.Contains("La Sablière"))!;

                Membre felix = context.Membres.FirstOrDefault(m => m.Prenom == "Félix" && m.Nom == "Séguin")!;
                Membre isabelle = context.Membres.FirstOrDefault(m => m.Prenom == "Isabelle" && m.Nom == "Passarelli")!;

                List<Membre> membres = new() { felix, isabelle };

				Seance seance = new()
                {
                    Jour = DayOfWeek.Wednesday,
                    HeureDebut = new TimeOnly(18, 30, 0), // 18h30
                    HeureFin = new TimeOnly(21, 30, 0),   // 21h30

                    QtePlaceMaximale = 21,
					QtePlaceOptimale = 16,

                    ResponsableId = felix.Id,

					MembresReguliers =membres,

					TerrainId = terrain8.IdTerrain,
				};

                await context.Seances.AddAsync(seance);
                await context.SaveChangesAsync();
			}
		}
    }
}
