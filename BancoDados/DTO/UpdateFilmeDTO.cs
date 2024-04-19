using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.BancoDados.DTO;

public class UpdateFilmeDTO
{
    
    [Required(ErrorMessage = "Titulo é obrigatório")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "Genero é obrigatório")]
    [StringLength(20, ErrorMessage = "Tamanho não pode exceder 20 Caracteres")]
    public string? Genero { get; set; }

    [Required(ErrorMessage = "Duracao é obrigatória")]
    [Range(90, 220, ErrorMessage = "Duracao deve ser entre 90 e 220 min")]
    public int Duracao { get; set; }

}
