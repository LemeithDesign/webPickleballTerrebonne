using Mapster;
using webPickleballTerrebonne.ObjetTransfertDonnee.Inscription;
using webPickleballTerrebonne.ObjetTransfertDonnee.PlagesHoraires;

namespace webPickleballTerrebonne.ObjetTransfertDonnee
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

            config.NewConfig<Data.Entites.PlageHoraire, PlageHorairePourIndexOtd>()
                .Map(dest => dest.HeureDebut, src => src.HeureDebut.ToString("HH:mm"))
                .Map(dest => dest.NomTerrain, src => src.Terrain.Nom);


            config.NewConfig<Data.Entites.PlageHoraire, PlageHorairePourDetailOtd>()
                .Map(dest => dest.NomTerrain, src => src.Terrain.Nom)
                .Map(dest => dest.Adresse, src => src.Terrain.Adresse)
                .Map(dest => dest.Ville, src => src.Terrain.Ville)
                .Map(dest => dest.CodePostal, src => src.Terrain.CodePostal)
                .Map(dest => dest.NomResponsable, src => $"{src.Responsable.Prenom} {src.Responsable.Nom}");


        }
    }
}