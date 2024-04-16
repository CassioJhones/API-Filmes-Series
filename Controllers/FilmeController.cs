using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new();
    private static int id = 0;
    [HttpPost]
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
        Console.WriteLine(filme.Genero);
    }

    [HttpGet]
    public IEnumerable<Filme> VerificarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 20)
        => filmes.Skip(skip).Take(take);

    [HttpGet("{id}")]
    public IActionResult VerificarFilmeID(int id)
    {
        var filme = filmes.FirstOrDefault(filmes => filmes.Id == id);
        if (filme is null) return NotFound("ID NAO ENCONTRADO");
        return Ok(filme);
    }
}
