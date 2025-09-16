using Mapster;
using web_PickleballTerrebonne.ObjetTransfertDonnee.Inscription;

namespace web_PickleballTerrebonne.ObjetTransfertDonnee
{
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Data.Entites.Inscription, InscriptionPourIndexOtd>();
            config.NewConfig<Data.Entites.Inscription, InscriptionPourCreerOtd>();
            config.NewConfig<Data.Entites.Inscription, InscriptionPourSupprimerOtd>();
            config.NewConfig<Data.Entites.Inscription, InscriptionPourModifierOtd>();
            config.NewConfig<Data.Entites.Inscription, InscriptionPourDetailsOtd>();
        }
    }
}