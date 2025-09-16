using Microsoft.EntityFrameworkCore;
using web_PickleballTerrebonne.Data.Contexts;
using web_PickleballTerrebonne.Data.Entites;

namespace web_PickleballTerrebonne.Data.Depot
{
    public interface IInscriptionData
    {
        #region Base
        Task<bool> SauvegarderAsync();
        #endregion Base
        #region Obtenir
        Task<List<Inscription>> ObtenirInscriptions();
        Task<Inscription?> ObtenirInscriptionParId(int inscriptionId);
        #endregion Obtenir
        #region Créer
        Task CreerInscriptionAsync(Inscription inscription);
        #endregion Créer
        #region Modifier
        Task ModifierInscription(Inscription inscription);
        #endregion Modifier
        #region Supprimer
        void SupprimerMusicien(Inscription inscription);
        #endregion Supprimer
    }

    public class InscriptionData(DataContext context) : IInscriptionData
    {
        #region Base
        private readonly DataContext _context = context;
        public async Task<bool> SauvegarderAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        #endregion Base

        #region Obtenir
        public async Task<List<Inscription>> ObtenirInscriptions()
        {
            return await _context.Inscriptions.ToListAsync();
        }
        public async Task<Inscription?> ObtenirInscriptionParId(int inscriptionId)
        {
            return await _context.FindAsync<Inscription>(inscriptionId);
        }
        #endregion Obtenir
        #region Créer
        public async Task CreerInscriptionAsync(Inscription inscription)
        {
            await _context.Inscriptions.AddAsync(inscription);
        }
        #endregion Créer
        #region Modifier
        public async Task ModifierInscription(Inscription inscription)
        {
            var  inscriptionDb = await _context.FindAsync<Inscription>(inscription.Id);
            if (inscriptionDb != null)
                _context.Entry(inscriptionDb).State = EntityState.Detached;
            _context.Entry(inscription).State = EntityState.Modified;
        }
        #endregion Modifier
        #region Supprimer
        public void SupprimerMusicien(Inscription inscription)
        {
            _context.Inscriptions.Remove(inscription);
        }
        #endregion Supprimer
    }
}
