using Microsoft.EntityFrameworkCore;
using webPickleballTerrebonne.Data.Contexts;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Data.Depot
{

    public interface IParticipationData
    {
        #region Base
        Task<bool> SauvegarderAsync();
        #endregion Base
        #region Obtenir
        Task<List<Participation>> ObtenirParticipationsAsync();
        #endregion Obtenir
        #region Créer
        #endregion Créer
        #region Modifier
        #endregion Modifier
        #region Supprimer
        #endregion Supprimer
    }
    public class ParticipationData(DataContext context) : IParticipationData
    {
        #region Base
        private readonly DataContext _context = context;
        public async Task<bool> SauvegarderAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        #endregion Base
        #region Obtenir
        public async Task<List<Participation>> ObtenirParticipationsAsync()
        {
            return await _context.Participations
                .Include(p => p.PlageHoraire.Terrain)
                .Include(p => p.PlageHoraire)
                .ToListAsync();
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
