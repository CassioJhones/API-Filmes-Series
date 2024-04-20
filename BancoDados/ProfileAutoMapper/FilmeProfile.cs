using AutoMapper;
using FilmesAPI.BancoDados.DTO;
using FilmesAPI.Models;

namespace FilmesAPI.BancoDados.ProfileAutoMapper;

public class FilmeProfile : Profile
{

    public FilmeProfile()
    {
        CreateMap<CreateFilmeDTO, Filme>();
        CreateMap<UpdateFilmeDTO, Filme>();
        CreateMap<Filme, UpdateFilmeDTO>();
        CreateMap<Filme, ReadFilmeDTO>();
    }
}
