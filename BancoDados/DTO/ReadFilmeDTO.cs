namespace FilmesAPI.BancoDados.DTO;
/// <summary>
/// DTO para representar os dados de um filme que serão lidos a partir do banco de dados.
/// </summary>
public class ReadFilmeDTO
{
    /// <summary>
    /// Recebe o Titulo do filme
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Define o Titulo do filme
    /// </summary>
    public string? Titulo { get; set; }
    /// <summary>
    /// Define o Genero do filme
    /// </summary>
    public string? Genero { get; set; }
    /// <summary>
    /// Define a Duracao do filme
    /// </summary>
    public int Duracao { get; set; }
    /// <summary>
    /// Define a Data que foi adicionado ao Banco de Dados
    /// </summary>
    public string AdicionadoEm { get; set; }
    /// <summary>
    /// Hora que a consulta foi realizada
    /// </summary>
    public string HoraConsulta { get; set; }

    public ReadFilmeDTO() => HoraConsulta = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
}
