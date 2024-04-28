namespace HaSe.Data.Project {
    public sealed class DepartmentData : EntityData {
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorId { get; set; }
    }
}
