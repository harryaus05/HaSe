using HaSe.Data.Contoso;

namespace HaSe.Domain.Project {
    public sealed class Instructor(InstructorData? data) : Entity<InstructorData>(data) {
        public string? FirstName => _data.FirstName;
        public string? LastName => _data.LastName;
        public DateTime HireDate => _data.HireDate;
        public override string ToString() {
            return $"{FirstName} {LastName}";
        }
    }
}
