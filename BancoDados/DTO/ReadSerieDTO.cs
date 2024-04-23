namespace FilmesAPI.BancoDados.DTO;

public class ReadSerieDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public int Temporadas { get; set; }
    public int Ano { get; set; }
    public string AdicionadoEm { get; set; }
    public string HoraConsulta { get; set; }

    public ReadSerieDTO() => HoraConsulta = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
}
