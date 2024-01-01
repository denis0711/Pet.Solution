using Pet.Domain.Models.Base;
using Pet.Domain.Models.Enum;

namespace Pet.Domain.Models;

public class Pet : Main
{
    public int? Idade { get; set; }
    public string? Nome { get; set; }
    public string? Raca { get; set; }
    public Sexo? Sexo { get; set; }
    public DateTime? DataRegistro { get; set; }
    public bool? Ativo { get; set; }
}
