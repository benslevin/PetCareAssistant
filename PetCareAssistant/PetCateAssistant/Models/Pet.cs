namespace PetCateAssistant.Models
{
    public class Pet
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public List<Weight> WeightLog { get; set; } = new();
        public List<TaskItem> Tasks { get; set; } = new();
    }
}
