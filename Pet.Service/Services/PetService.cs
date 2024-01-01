using AutoMapper;
using Pet.Domain.Interfaces;
using Pet.Service.DTOs;
using Pet.Service.Interfaces;

namespace Pet.Service.Services;

public class PetService : IPetService
{
    protected IPetRepository petRepository;
    protected IMapper _mapper;

    public PetService(IPetRepository petRepository, IMapper mapper)
    {
        this.petRepository = petRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PetDTO>> GetAll()
    {
        var retorno = _mapper.Map<IEnumerable<PetDTO>>(await petRepository.GetAll());
        return retorno;
    }

    public async Task<PetDTO> GetAllById(int? id)
    {
        var retorno = _mapper.Map<PetDTO>(await petRepository.GetAllById(id));
        return retorno;
    }

    public async Task<PetDTO> UpdatePet(int? id, PetDTO pet)
    {
        var petEntity = _mapper.Map<Pet.Domain.Models.Pet>(pet);
        petEntity.Id = id;

        await petRepository.UpdatePet(id,petEntity);

        return pet;

    }

    public async Task<PetDTO> AddPet(PetDTO pet)
    {
        var petEntity = _mapper.Map<Pet.Domain.Models.Pet>(pet);

        await petRepository.AddPet(petEntity);

        return _mapper.Map<PetDTO>(petEntity);
    }

    public async Task<PetDTO> Delete(int? id)
    {
        var retorno =  await petRepository.Delete(id);
        return _mapper.Map<PetDTO>(retorno);
    }
}
