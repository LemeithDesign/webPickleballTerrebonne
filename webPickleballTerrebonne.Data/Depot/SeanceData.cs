using Microsoft.EntityFrameworkCore;
using webPickleballTerrebonne.Data.Contexts;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Data.Depot
{
    public interface ISeanceData
    {
        #region Base
        //Task<bool> SauvegarderAsync();
        #endregion Base
        #region Obtenir
        Task<List<Seance>> ObtenirSeances();
        Task<Seance?> ObtenirSeanceParId(int idSeance);
        #endregion Obtenir
        #region Créer
        #endregion Créer
        #region Modifier
        #endregion Modifier
        #region Supprimer
        #endregion Supprimer
    }
    public class SeanceData(DataContext context) : ISeanceData
    {
        #region Base
        private readonly DataContext _context = context;
        public async Task<bool> SauvegarderAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        #endregion Base
        #region Obtenir
        public async Task<List<Seance>> ObtenirSeances()
        {
            return await _context.Seances
                .Include(s => s.Terrain)
                .ToListAsync();
        }
        public async Task<Seance?> ObtenirSeanceParId(int idSeance)
        {
            return await _context.Seances
                .Include(s => s.Terrain)
                .Include(s => s.Responsable)
                .FirstOrDefaultAsync(s => s.IdSeance == idSeance);
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
