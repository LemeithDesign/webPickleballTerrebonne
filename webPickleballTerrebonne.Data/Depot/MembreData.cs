using Humanizer;
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
        #endregion Obtenir
        #region Créer
        Task<int> CreerMembreAsync(Membre membre);
        //Task<IdentityResult> CreerMembreAsync(string email, string pw);
        #endregion Créer
        #region Modifier
        Task ModifierMembreAsync(Membre membre);
        #endregion Modifier
        #region Supprimer
        Task SupprimerMembreAsync(int id);
        #endregion Supprimer
    }

    public class MembreData(UserManager<ApplicationUser> userManage, DataContext context) : IMembreData
    {
        #region Base
        private readonly DataContext _context = context;
        private readonly UserManager<ApplicationUser> _userManager = userManage;
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
        #endregion Obtenir
        #region Créer
        public async Task<int> CreerMembreAsync(Membre membre)
        {
            await _context.Membres.AddAsync(membre);
            await SauvegarderAsync();
            return membre.Id;
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
        public async Task SupprimerMembreAsync(int id)
        {
            var membre = await ObtenirMembreParIdAsync(id);
            if (membre != null)
            {
                _context.Membres.Remove(membre);
                await _context.SaveChangesAsync();
            }
        }
        #endregion Supprimer
    }
}
