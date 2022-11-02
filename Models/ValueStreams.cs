namespace CredexAPI.Models
{
    public class ValueStreams
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Employees>? Employees { get; set; }
        public virtual ICollection<Jobs>? Jobs { get; set; }
    }
}
