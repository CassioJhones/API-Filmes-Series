﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.BancoDados.DTO;

public class CreateSerieDTO
{
    [Required(ErrorMessage = "Título é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Ano é obrigatório")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "Gênero é obrigatório")]
    [StringLength(20, ErrorMessage = "O tamanho do gênero não pode exceder 20 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "Duração é obrigatória")]
    [Range(20, 60, ErrorMessage = "A duração deve estar entre 20 e 60 episódios")]
    public int Duracao { get; set; }

    public string AdicionadoEm { get; set; }

    public CreateSerieDTO()
    {
        AdicionadoEm = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }
}