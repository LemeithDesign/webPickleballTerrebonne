using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webPickleballTerrebonne.Data.Contexts;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Data.Depot
{
    public interface IMembreData
    {
        #region Base
        Task<bool> SauvegarderAsync();
        #endregion Base
        #region Obtenir
        Task<List<Membre>> ObtenirMembresAsync();
        Task<Membre?> ObtenirMembreParIdAsync(int membreId);

        Task<IList<string>> ObtenirRolesMembreParIdAsync(int membreId);
        #endregion Obtenir
        #region Créer
        Task<int> CreerMembreAsync(Membre membre);
        //Task<IdentityResult> CreerMembreAsync(string email, string pw);
        #endregion Créer
        #region Modifier
        Task ModifierMembreAsync(Membre membre);
        #endregion Modifier
        #region Supprimer
        Task SupprimerMembreAsync(Membre membre);
        Task SupprimerMembreAsync(int id);
        #endregion Supprimer
    }

    public class MembreData(UserManager<ApplicationUser> userManager, DataContext context) : IMembreData
    {
        #region Base
        private readonly DataContext _context = context;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        public async Task<bool> SauvegarderAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        #endregion Base
        #region Obtenir
        public async Task<List<Membre>> ObtenirMembresAsync()
        {
            return await _context.Membres
                .Include(m => m.ApplicationUser)
                .ToListAsync();
        }
        public async Task<Membre?> ObtenirMembreParIdAsync(int membreId)
        {
            return await _context.Membres
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == membreId);            
        }

        public async Task<IList<string>> ObtenirRolesMembreParIdAsync(int membreId)
        {
            var membre =  await ObtenirMembreParIdAsync(membreId);
            if (membre == null || membre.ApplicationUser == null)
            {
                return [];
            }
            return await _userManager.GetRolesAsync(membre.ApplicationUser);
        }



        #endregion Obtenir
        #region Créer
        public async Task<int> CreerMembreAsync(Membre membre)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);

            try
            {

                int nextNoMembre = context.Membres.Any()
                        ? context.Membres.Max(m => m.NoMembre) + 1
                        : 1;
                membre.NoMembre = nextNoMembre;

                await _context.Membres.AddAsync(membre);
                await SauvegarderAsync();
                await transaction.CommitAsync();
                return membre.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        #endregion Créer
        #region Modifier
        public async Task ModifierMembreAsync(Membre membre)
        {
            _context.Membres.Update(membre);
            await _context.SaveChangesAsync();
        }

        #endregion Modifier
        #region Supprimer
        public async Task SupprimerMembreAsync(Membre membre)
        {
            _context.Membres.Remove(membre);
            await _context.SaveChangesAsync();
        }
        public async Task SupprimerMembreAsync(int id)
        {
            var membre = await ObtenirMembreParIdAsync(id);
            if (membre != null)
            {
                await SupprimerMembreAsync(membre);
            }
        }
        #endregion Supprimer
    }
}
