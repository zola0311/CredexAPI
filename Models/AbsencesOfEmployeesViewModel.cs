namespace CredexAPI.Models
{
    public class AbsencesOfEmployeesViewModel
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public int AbsenceTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}
