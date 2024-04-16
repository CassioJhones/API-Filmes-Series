using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.BancoDados;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> config) : base(config)
    {}

    public DbSet<Filme> Filmes { get; set; }

}
