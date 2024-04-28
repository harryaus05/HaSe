namespace HaSe.Data.Project
{
    public sealed class StudentData : EntityData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}