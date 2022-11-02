namespace CredexAPI.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? JobKey { get; set; }
        public int Salary { get; set; }
        public int ValueStreamId { get; set; }
        public virtual ICollection<Employees>? Employees { get; set; }
        public virtual ValueStreams? ValueStreams { get; set; }
        

    }
}
