using PetCateAssistant.Models;

namespace PetCateAssistant.Services
{
    public interface IPetService
    {
        Task<List<Pet>> GetAllAsync();
        Task<Pet?> GetByIdAsync(string id);
        Task AddAsync(Pet pet);
        Task<bool> DeleteAsync(string id);
        Task SaveAsync();
    }
}
