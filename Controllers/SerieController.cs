using AutoMapper;
using FilmesAPI.BancoDados;
using FilmesAPI.BancoDados.DTO;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AdicionaSerie([FromBody] CreateSerieDTO serieDTO)
    {
        Serie serie = _mapper.Map<Serie>(serieDTO);

        _BancoDados.Series.Add(serie);
        _BancoDados.SaveChanges();
        return Ok(serie);
       // return CreatedAtAction(nameof(VerificarFilmeID), new { id = serie.Id }, serie);
    }

}
