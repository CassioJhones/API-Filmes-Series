﻿namespace FilmesAPI.BancoDados.DTO;

public class ReadFilmeDTO
{
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraConsulta { get; set; } = DateTime.Now;
}