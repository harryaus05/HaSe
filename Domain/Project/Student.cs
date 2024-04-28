using HaSe.Data.Project;

namespace HaSe.Domain.Project {
    public sealed class Student(StudentData? data) : Entity<StudentData>(data) {
        public string? FirstName => _data.FirstName;
        public string? LastName => _data.LastName;
        public DateTime EnrollmentDate => _data.EnrollmentDate;
    }
}
