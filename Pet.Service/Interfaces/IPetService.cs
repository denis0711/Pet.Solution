using Pet.Service.DTOs;

namespace Pet.Service.Interfaces;

public interface IPetService
{
    Task<IEnumerable<PetDTO>> GetAll();
    Task<PetDTO> GetAllById(int? id);
    Task<PetDTO> AddPet(PetDTO pet);
    Task<PetDTO> UpdatePet(int? id, PetDTO pet);
    Task<PetDTO> Delete(int? id);
}
