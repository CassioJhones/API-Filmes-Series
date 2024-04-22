using AutoMapper;
using FilmesAPI.BancoDados;
using FilmesAPI.BancoDados.DTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
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

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDTO">Objeto com os campos necessarios</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Filme adicionado com Sucesso</response>
    /// <response code="400">Faltando campos necessarios</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(filmeDTO);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(VerificarFilmeID), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Busca todos os filmes salvos no Banco de Dados
    /// </summary>
    /// <param name="skip">Quantidade de filmes para pular</param>
    /// <param name="take">Quantidade de filmes para exibir</param>
    /// <returns>Uma lista de filmes.</returns>
    /// <response code="200">Lista de filmes retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadFilmeDTO> VerificarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.Skip(skip).Take(take));
    }

    /// <summary>
    /// Verifica um filme pelo Id
    /// </summary>
    /// <param name="id">Id do filme desejado</param>
    /// <returns>IActionResult</returns>
    /// <response code="404">O Filme buscado não existe no Banco de Dados</response>
    /// <response code="200">O Filme buscado foi encontrado</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult VerificarFilmeID(int id)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme is null) return NotFound("ID NAO ENCONTRADO");

        ReadFilmeDTO filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
        return Ok(filmeDto);
    }

    /// <summary>
    /// Altera TODOS os dados de um filme
    /// </summary>
    /// <param name="id">id do filme</param>
    /// <param name="filmeDTO">Dados do filme a serem atualizados.</param>
    /// <returns>IActionResult</returns>
    [HttpPut("{id}")]//PUT atualiza obj/json inteiro
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme is null) return NotFound("ID NAO ENCONTRADO");
        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Altera os dados de um filme de modo PARCIAL
    /// </summary>
    /// <param name="id">Id do Filme</param>
    /// <param name="mudanca">Informação que deseja alterar</param>
    /// <returns>IActionResult</returns>
    [HttpPatch("{id}")]//PATCH atualiza parte do obj/json
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> mudanca)
    {
        string campo = mudanca.Operations[0].path.Replace("/", "").Trim().ToUpper();
        object valor = mudanca.Operations[0].value;
        Filme? filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme is null) return NotFound("ID NAO ENCONTRADO");

        PropertyInfo[] propriedadesObj = filme.GetType().GetProperties();
        foreach (PropertyInfo Campo in propriedadesObj)
        {
            if (Campo.Name.Equals(campo, StringComparison.CurrentCultureIgnoreCase))
            {
                object? propValue = Campo.GetValue(filme);
                if (propValue != null && propValue.Equals(valor))
                    return BadRequest($"O campo {campo} já tem o valor {valor}");
            }
        }

        UpdateFilmeDTO filmeAtualizado = _mapper.Map<UpdateFilmeDTO>(filme);

        mudanca.ApplyTo(filmeAtualizado, ModelState);

        if (!TryValidateModel(filmeAtualizado))
            return ValidationProblem(ModelState);

        _mapper.Map(filmeAtualizado, filme);
        _context.SaveChanges();
        return Ok($"Alteracao Realizada do campo {campo} para {valor}");
    }

    /// <summary>
    /// Apaga o filme do banco de dados
    /// </summary>
    /// <param name="id">Id do filme desejado</param>
    /// <returns>IActionResult</returns>
    /// <response code="404">O Filme buscado não existe no Banco de Dados</response>
    /// <response code="200">O Filme buscado foi Apagado</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeletarFime(int id)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme is null) return NotFound("ID NAO ENCONTRADO");

        _context.Remove(filme);
        _context.SaveChanges();
        return Ok($"Filme Deletado: {id} - {filme.Titulo}");
    }
}
