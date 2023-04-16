namespace CredexAPI.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Employees>? Employees { get; set; }
        

    }
}
