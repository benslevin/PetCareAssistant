namespace PetCateAssistant.Services
{
    public class FileService: IFileService
    {
        public bool Exists(string filePath) => File.Exists(filePath);
        public string ReadAllText(string filePath) => File.ReadAllText(filePath);
        public void WriteAllText(string filePath, string content) => File.WriteAllText(filePath, content);
        public void Create(string filePath) => File.Create(filePath).Dispose();
    }
}
