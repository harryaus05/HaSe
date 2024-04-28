using HaSe.Data.Contoso;

namespace HaSe.Domain.Project {
    public sealed class Department(DepartmentData? data) : Entity<DepartmentData>(data) {
        public string? Name => _data.Name;
        public decimal Budget => _data.Budget;
        public DateTime StartDate => _data.StartDate;
        public int? InstructorId => _data.InstructorId;
    }
}
