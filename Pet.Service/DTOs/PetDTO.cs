using Pet.Service.Models.Enum;

namespace Pet.Service.DTOs;

public class PetDTO
{
    public int? Idade { get; set; }
    public string? Nome { get; set; }
    public string? Raca { get; set; }
    public DateTime? DataRegistro { get; set; }
    public bool? Ativo { get; set; }
    public Sexo? Sexo { get; set; }
}
