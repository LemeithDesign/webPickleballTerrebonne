using Microsoft.EntityFrameworkCore;
using webPickleballTerrebonne.Data.Contexts;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Data.Depot
{
    public interface IPlageHoraireData
    {
        #region Base
        //Task<bool> SauvegarderAsync();
        #endregion Base
        #region Obtenir
        Task<List<PlageHoraire>> ObtenirPlagesHoraires();
        Task<PlageHoraire?> ObtenirPlageHoraireParId(int idPlageHoraire);
        #endregion Obtenir
        #region Créer
        #endregion Créer
        #region Modifier
        #endregion Modifier
        #region Supprimer
        #endregion Supprimer
    }
    public class PlageHoraireData(DataContext context) : IPlageHoraireData
    {
        #region Base
        private readonly DataContext _context = context;
        public async Task<bool> SauvegarderAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        #endregion Base
        #region Obtenir
        public async Task<List<PlageHoraire>> ObtenirPlagesHoraires()
        {
            return await _context.PlagesHoraires
                .Include(s => s.Terrain)
                .ToListAsync();
        }
        public async Task<PlageHoraire?> ObtenirPlageHoraireParId(int idPlageHoraire)
        {
            return await _context.PlagesHoraires
                .Include(s => s.Terrain)
                .Include(s => s.Responsable)
                .FirstOrDefaultAsync(s => s.IdPlageHoraire == idPlageHoraire);
        }
        #endregion Obtenir
        #region Créer
        #endregion Créer
        #region Modifier
        #endregion Modifier
        #region Supprimer
        #endregion Supprimer
    }
}
