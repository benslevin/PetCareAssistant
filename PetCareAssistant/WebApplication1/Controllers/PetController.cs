using Microsoft.AspNetCore.Mvc;
using PetCateAssistant.Models;
using PetCateAssistant.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _petService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var pet = await _petService.GetByIdAsync(id);
            return pet is null ? NotFound() : Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Pet pet)
        {
            await _petService.AddAsync(pet);
            return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _petService.DeleteAsync(id);
            return deleted? NoContent() : NotFound();
        }
    }
}
