namespace CredexAPI.Models
{
    public class Statuses
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? StatusKey { get; set; }
        public bool IsActive { get; set; } 
        public virtual ICollection<Employees>? Employees { get; set; }
    }
}
