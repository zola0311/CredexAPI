namespace CredexAPI.Models
{
    public class Statuses
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Employees>? Employees { get; set; }
    }
}
