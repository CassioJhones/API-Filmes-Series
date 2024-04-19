using AutoMapper;
using FilmesAPI.BancoDados;
using FilmesAPI.BancoDados.DTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(filmeDTO);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(VerificarFilmeID), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> VerificarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 20) => _context.Filmes.Skip(skip).Take(take);

    [HttpGet("{id}")]
    public IActionResult VerificarFilmeID(int id)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
        return filme is null ? NotFound("ID NAO ENCONTRADO") : Ok(filme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme is null) return NotFound("ID NAO ENCONTRADO");
        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
    }
}
