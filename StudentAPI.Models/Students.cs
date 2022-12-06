namespace StudentAPI.Models
{
    public class Students
    {
        public int Id { get; set; } //Auto increatment
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
    }
}