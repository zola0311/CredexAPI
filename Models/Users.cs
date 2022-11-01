namespace CredexAPI.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public virtual Roles? Roles { get; set; }

    }
}
