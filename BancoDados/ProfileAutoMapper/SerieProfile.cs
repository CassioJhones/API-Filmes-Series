using AutoMapper;
using FilmesAPI.BancoDados.DTO;
using FilmesAPI.Models;

namespace FilmesAPI.BancoDados.ProfileAutoMapper
{
    /// <summary>
    /// Perfil do AutoMapper para mapear entre os DTOs e o modelo Serie.
    /// </summary>
    public class SerieProfile : Profile
    {
        /// <summary>
        /// Inicializa uma nova instância da classe SerieProfile.
        /// </summary>
        public SerieProfile()
        {
            CreateMap<CreateSerieDTO, Serie>();
            //CreateMap<Serie, ReadSerieDTO>();
        }
    }
}
