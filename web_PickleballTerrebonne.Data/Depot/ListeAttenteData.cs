using Microsoft.EntityFrameworkCore;
using web_PickleballTerrebonne.Data.Contexts;
using web_PickleballTerrebonne.Data.Entites;

namespace web_PickleballTerrebonne.Data.Depot
{
    public interface IListeAttenteData
    {
        #region Base
        Task<bool> SauvegarderAsync();
        #endregion Base
        #region Obtenir
        Task<EntreeListeAttente?> ObtenirEntreeParId(string attenteId);
        Task<int> ObternirPosition();
        Task<int> ObternirPositionEntree(EntreeListeAttente entree);
        Task<int> VerifierCapacite();
        #endregion Obtenir
        #region Créer
        Task CreerEntreeAsync(EntreeListeAttente entree);
        #endregion Créer
        #region Modifier
        #endregion Modifier
        #region Supprimer
        #endregion Supprimer
    }

    public class ListeAttenteData(DataContext context) : IListeAttenteData
    {
        #region Base
        private readonly DataContext _context = context;
        public async Task<bool> SauvegarderAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        #endregion Base
        #region Obtenir

        public async Task<EntreeListeAttente?> ObtenirEntreeParId(string attenteId)
        {
            return await _context.EntreesListeAttente.FirstOrDefaultAsync(e => e.UserId == attenteId);
        }
        public async Task<int> ObternirPositionEntree(EntreeListeAttente entree)
        {
            int position = await _context.EntreesListeAttente.CountAsync(e => e.Statut == Data.Enum.StatutAttente.EnAttente && e.Timestamp < entree.Timestamp);
            return position + 1;
        }
        public async Task<int> ObternirPosition()
        {
            return await _context.EntreesListeAttente.CountAsync(e => e.Statut == Data.Enum.StatutAttente.EnAttente) + 1;
        }
        public async Task<int> VerifierCapacite()
        {
            return await _context.EntreesListeAttente.CountAsync(e => e.Statut == Data.Enum.StatutAttente.EnCours);
        }
        #endregion Obtenir
        #region Créer
        public async Task CreerEntreeAsync(EntreeListeAttente entree)
        {
            await _context.EntreesListeAttente.AddAsync(entree);
        }
        #endregion Créer
        #region Modifier
        #endregion Modifier
        #region Supprimer
        #endregion Supprimer
    }
}
