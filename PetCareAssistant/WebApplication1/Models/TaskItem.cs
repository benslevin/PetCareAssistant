namespace PetCateAssistant.Models
{
    public class TaskItem
    {
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool Completed { get; set; } = false;
    }
}
