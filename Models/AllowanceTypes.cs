namespace CredexAPI.Models
{
    public class AllowanceTypes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<AllowancesOfEmployees>? AllowancesOfEmployees { get; set; }
    }
}
