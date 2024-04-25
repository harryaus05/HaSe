namespace HaSe.Data.Contoso
{
    public sealed class StudentData : EntityData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}