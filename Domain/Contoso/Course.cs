using HaSe.Data.Contoso;

namespace HaSe.Domain.Contoso {
    public sealed class Course(CourseData? data) : Entity<CourseData>(data) {
        public string? Title => _data.Title;
        public int Credits => _data.Credits;
        public int DepartmentId => _data.DepartmentId;
    }
}
