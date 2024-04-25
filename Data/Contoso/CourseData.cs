namespace HaSe.Data.Contoso
{
    public sealed class CourseData : EntityData {
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
    }
}
