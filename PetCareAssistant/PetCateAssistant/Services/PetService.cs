using Microsoft.Extensions.Options;
using PetCateAssistant.Models;
using System.Text.Json;

namespace PetCateAssistant.Services
{
    public class PetService : IPetService
    {
        private readonly string _filePath;
        private readonly IFileService _fileService;
        private List<Pet> _pets = new();

        public PetService(IFileService fileService, IOptions<PetDataOptions> options)
        {
            _fileService = fileService;
            _filePath = options.Value.FilePath;
            if (_fileService.Exists(_filePath))
            {
                var json = _fileService.ReadAllText(_filePath);
                _pets = JsonSerializer.Deserialize<List<Pet>>(json) ?? new();
            }
        }

        public Task InitializeAsync()
        {
            if (!_fileService.Exists(_filePath))
            {
                _fileService.CreateDirectory(_fileService.GetDirectoryName(_filePath)!);
                _fileService.WriteAllText(_filePath, "[]");
            }
            return Task.CompletedTask;
        }

        public Task AddAsync(Pet pet)
        {
            _pets.Add(pet);
            return SaveAsync();
        }

        public Task<bool> DeleteAsync(string id)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if(pet is null)
            {
                return Task.FromResult(false);
            }
            _pets.Remove(pet);
            return SaveAsync().ContinueWith(_ => true);
        }

        public Task<List<Pet>> GetAllAsync() => Task.FromResult(_pets);

        public Task<Pet?> GetByIdAsync(string id) => Task.FromResult(_pets.FirstOrDefault(p => p.Id == id));

        public Task SaveAsync()
        {
            var json = JsonSerializer.Serialize(_pets, new JsonSerializerOptions { WriteIndented = true});
            _fileService.WriteAllText(_filePath, json);
            return Task.CompletedTask;
        }
    }
}
