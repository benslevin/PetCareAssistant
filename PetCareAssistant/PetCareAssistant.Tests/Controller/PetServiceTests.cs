using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using PetCateAssistant.Models;
using PetCateAssistant.Services;
using System.Runtime.CompilerServices;

namespace PetCareAssistant.Tests
{
    public class PetServiceTests
    {
        private readonly Mock<IFileService> _fileServiceMock;
        private readonly PetService _service;
        private readonly string _testPath = Path.Combine("Data", "pets.json");

        public PetServiceTests()
        {
            _fileServiceMock = new Mock<IFileService>();

            _fileServiceMock.Setup(f => f.Exists(It.IsAny<string>())).Returns(true);
            _fileServiceMock.Setup(f => f.ReadAllText(It.IsAny<string>())).Returns("[]");

            _service = new PetService(_fileServiceMock.Object);
        }

        [Fact]
        public async Task AddAsync_AddPet()
        {
            var pet = new Pet { Id = "1", Name = "James", Species = "Dog"};

            await _service.AddAsync(pet);
            var allPets = await _service.GetAllAsync();

            Assert.Single(allPets);
            Assert.Equal("James", allPets[0].Name);

            _fileServiceMock.Verify(f => f.WriteAllText(_testPath, It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_RemovesPet()
        {
            var pet = new Pet { Id = "2", Name = "Milo", Species = "Cat" };
            await _service.AddAsync(pet);

            var result = await _service.DeleteAsync("2");
            var pets = await _service.GetAllAsync();

            Assert.True(result);
            Assert.Empty(pets);
        }
    }
}
