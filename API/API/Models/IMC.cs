using System;

namespace API.Models;

public class IMC
{
    public string? ImcId { get; set; }
    public float Peso { get; set; }
    public float Altura { get; set; }
    public Aluno? Aluno { get; set; } 
    public string? AlunoId { get; set; }
    public string? Classificacao { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}
