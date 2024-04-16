using FilmesAPI.BancoDados;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;

    public FilmeController(FilmeContext context) => _context = context;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(VerificarFilmeID), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> VerificarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 20)
        => _context.Filmes.Skip(skip).Take(take);

    [HttpGet("{id}")]
    public IActionResult VerificarFilmeID(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
        if (filme is null) return NotFound("ID NAO ENCONTRADO");
        return Ok(filme);
    }
}
