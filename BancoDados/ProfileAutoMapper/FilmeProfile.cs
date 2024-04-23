using AutoMapper;
using FilmesAPI.BancoDados.DTO.Filme;
using FilmesAPI.Models;

namespace FilmesAPI.BancoDados.ProfileAutoMapper;

/// <summary>
/// Perfil do AutoMapper para mapear entre os DTOs e o modelo Filme.
/// </summary>
public class FilmeProfile : Profile
{
    /// <summary>
    /// Inicializa uma nova instância da classe FilmeProfile.
    /// </summary>
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDTO, Filme>();
        CreateMap<UpdateFilmeDTO, Filme>();
        CreateMap<Filme, UpdateFilmeDTO>();
        CreateMap<Filme, ReadFilmeDTO>();
    }
}
