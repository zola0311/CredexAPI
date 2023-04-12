namespace CredexAPI.Models
{
    public class AbsenceTypes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<AbsencesOfEmployees>? AbsencesOfEmployees { get; set; }
    }
}
