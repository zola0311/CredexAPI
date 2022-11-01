namespace CredexAPI.Models
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? BirthName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IdentityCardNumber { get; set; }
        public int GenderId { get; set; }
        public int ValueStreamId { get; set; }
        public string? NameOfMother { get; set; }
        public int PostalCode { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int JobId { get; set; }
        public int StatusId { get; set; }

        public virtual Statuses? Statuses { get; set; }
        public virtual ICollection<AllowancesOfEmployees>? AllowancesOfEmployees { get; set; }
        public virtual Jobs? Jobs { get; set; }
        public virtual ValueStreams? ValueStreams { get; set; }
        public virtual Genders? Genders { get; set; }
    }
}
