using HaSe.Data.Contoso;

namespace HaSe.Domain.Contoso {
    public sealed class Student(StudentData? data) : Entity<StudentData>(data) {
        public string? FirstName => _data.FirstName;
        public string? LastName => _data.LastName;
        public DateTime EnrollmentDate => _data.EnrollmentDate;
    }
}
