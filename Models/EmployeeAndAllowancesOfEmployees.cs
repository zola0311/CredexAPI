namespace CredexAPI.Models
{
    public class EmployeeAndAllowancesOfEmployees
    {
        public Employees? Employee { get; set; }
        public List<AllowancesOfEmployees>? AllowancesOfEmployees { get; set; }
    }
}
