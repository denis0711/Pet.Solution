using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Domain.Models;

namespace Pet.Domain.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet.Domain.Models.Pet>> GetAll();
    Task<Pet.Domain.Models.Pet> GetAllById(int? id);
    Task<Pet.Domain.Models.Pet> AddPet(Pet.Domain.Models.Pet pet);
    Task<Pet.Domain.Models.Pet> UpdatePet(int? id, Pet.Domain.Models.Pet pet);
    Task<Pet.Domain.Models.Pet> Delete(int? id);
}
