using AutoMapper;
using FilmesAPI.BancoDados;
using FilmesAPI.BancoDados.DTO.Serie;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class SerieController : ControllerBase
{
    private FilmeContext _BancoDados;
    private IMapper _mapper;
    public SerieController(FilmeContext context, IMapper mapper)
    {
        _BancoDados = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona uma serie ao banco de dados
    /// </summary>
    /// <param name="serieDTO">Objeto com os campos necessarios</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Serie adicionada com Sucesso</response>
    /// <response code="400">Faltando campos necessarios</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AdicionaSerie([FromBody] CreateSerieDTO serieDTO)
    {
        Serie serie = _mapper.Map<Serie>(serieDTO);

        _BancoDados.Series.Add(serie);
        _BancoDados.SaveChanges();
        return CreatedAtAction(nameof(VerificarSeriesID), new { id = serie.Id }, serie);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadSerieDTO> VerificarSeries
        ([FromQuery] int skip = 0, [FromQuery] int take = 50,
        [FromQuery] string genero = null,
        [FromQuery] int? ano = null,
        [FromQuery] int? temporada = null)
    {
        IQueryable<Serie> consulta = _BancoDados.Series;

        if (!string.IsNullOrEmpty(genero))
            consulta = consulta.Where(x => x.Genero == genero);

        if (ano != null)
            consulta = consulta.Where(x => x.Ano == ano);

        if (temporada != null)
            consulta = consulta.Where(x => x.Temporadas == temporada);

        consulta = consulta.Skip(skip).Take(take);
        return _mapper.Map<List<ReadSerieDTO>>(consulta.ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult VerificarSeriesID(int id)
    {
        Serie? serie = _BancoDados.Series.FirstOrDefault(x => x.Id == id);
        if (serie is null) return NotFound("FILME NAO ENCONTRADO");

        ReadSerieDTO serieDTO = _mapper.Map<ReadSerieDTO>(serie);
        return Ok(serieDTO);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeletarSerie(int id)
    {
        Serie? Serie = _BancoDados.Series.FirstOrDefault(x => x.Id == id);
        if (Serie is null) return NotFound("ID NAO ENCONTRADO");

        _BancoDados.Remove(Serie);
        _BancoDados.SaveChanges();
        return Ok($"Série Deletada: {id} - {Serie.Titulo}/{Serie.Ano}");
    }
}
