using AutoMapper;
using FilmesAPI.BancoDados.DTO;
using FilmesAPI.Models;

namespace FilmesAPI.BancoDados.ProfileAutoMapper
{
    public class SerieProfile : Profile
    {
        public SerieProfile()
        {
            CreateMap<CreateSerieDTO, Serie>();
            CreateMap<Serie, ReadSerieDTO>();
        }
    }
}
