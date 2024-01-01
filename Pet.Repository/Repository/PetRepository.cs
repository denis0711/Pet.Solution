using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Pet.Domain.Interfaces;
using Pet.Domain.Models;
using Pet.Repository.Banco;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Repository.Repository;

public class PetRepository : IPetRepository
{

    protected readonly MeuBancoContext meuBanco;

    public PetRepository(MeuBancoContext meuBanco)
    {
        this.meuBanco = meuBanco;
    }

    public async Task<IEnumerable<Domain.Models.Pet>> GetAll()
    {
        var retorno = await this.meuBanco.Pets.AsNoTracking().ToListAsync();
        return retorno;
    }

    public async Task<Domain.Models.Pet> GetAllById(int? id)
    {
        var retorno = await this.meuBanco.Pets.AsNoTracking().FirstOrDefaultAsync(a=> a.Id == id);
        return retorno;
    }

    public async Task<Domain.Models.Pet> AddPet(Domain.Models.Pet pet)
    {
        var retorno = pet;
        await this.meuBanco.Pets.AddAsync(pet);
        this.meuBanco.SaveChanges();

        return pet;
    }

    public async Task<Domain.Models.Pet> UpdatePet(int? id, Domain.Models.Pet pet)
    {
        var existingPet = await this.meuBanco.Pets.FindAsync(id);

        if (existingPet != null)
        {
            existingPet.Nome = pet.Nome is null ? existingPet.Nome : pet.Nome;
            existingPet.Idade = pet.Idade is null ? existingPet.Idade: pet.Idade;
            existingPet.Raca = pet.Raca;
            existingPet.DataRegistro = pet.DataRegistro is null ? existingPet.DataRegistro : pet.DataRegistro;
            existingPet.Ativo = pet.Ativo is null? existingPet.Ativo : pet.Ativo;
 

            this.meuBanco.Pets.Update(existingPet);
            await this.meuBanco.SaveChangesAsync();

            return existingPet;
        }else
        {
           return  new Domain.Models.Pet();
        }

       
    }

    public async Task<Domain.Models.Pet> Delete(int? id)
    {
        var pet = await GetAllById(id);

        if (pet != null)
        {
           this.meuBanco.Pets.Remove(pet);
           this.meuBanco.SaveChanges();
        }

        return pet;
    }

}
