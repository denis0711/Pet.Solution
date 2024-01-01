using AutoMapper;
using Pet.Domain.Models.Enum;
using Pet.Service.DTOs;

namespace Pet.Service.AutoMappers;

public class Mapper : Profile
{
    public Mapper()
    {
        this.CreateMap<PetDTO, Pet.Domain.Models.Pet>().ReverseMap();
        this.CreateMap<Sexo, Pet.Service.Models.Enum.Sexo>().ReverseMap();

 
    }
}
