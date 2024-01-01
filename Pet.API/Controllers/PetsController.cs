using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Pet.Service.DTOs;
using Pet.Service.Interfaces;

namespace Pet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        protected readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("MostrarTodos")]
        public async Task<IActionResult> Get()
        {
            var resultado = await _petService.GetAll();
            return Ok(resultado);
        }


        [HttpGet("MostrarDetalhe")]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _petService.GetAllById(id);
            if (resultado != null)
            {
                return Ok(resultado);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Post(PetDTO pet)
        {
            try{
                var resultado = await _petService.AddPet(pet);
                return Ok(resultado);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
           
        }


        [HttpPut("Alterar")]
        public async Task<IActionResult> Put(int id, PetDTO pet)
        {
            var resultado = await _petService.UpdatePet(id,pet);
            return Ok(resultado);
        }
        
        [HttpDelete("Deletar")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _petService.Delete(id);
            return Ok(resultado);
        }
    }
}
