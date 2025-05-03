namespace PetCateAssistant.Services
{
    public interface IFileService
    {
        bool Exists(string filePath);
        string ReadAllText(string filePath);
        void WriteAllText(string filePath, string content);
        void Create(string filePath);
        void CreateDirectory(string directoryPath);
        string GetDirectoryName(string directoryPath);
    }
}
