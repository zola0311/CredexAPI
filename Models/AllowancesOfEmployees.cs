namespace CredexAPI.Models
{
    public class AllowancesOfEmployees
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? AllowanceTypeId { get; set; }
        public int Value { get; set; }
        public virtual ICollection<Employees>? Employees { get; set; }
        public virtual AllowanceTypes AllowanceTypes { get; set; }
    }
}
