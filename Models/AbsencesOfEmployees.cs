using System.ComponentModel.DataAnnotations;

namespace CredexAPI.Models
{
    public class AbsencesOfEmployees
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int AbsenceTypeId { get; set; }
        public virtual Employees? Employees { get; set; }
        public virtual AbsenceTypes AbsenceTypes { get; set; }
    }
}
