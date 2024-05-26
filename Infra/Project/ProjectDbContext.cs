using HaSe.Data.Project;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project
{
    public class ProjectDbContext(DbContextOptions<ProjectDbContext> options) : BaseDbContext<ProjectDbContext>(options)
    {
        internal const string _projectSchema = "Project";
        internal const string _decimal = "decimal(16,4)";

        public DbSet<PartSpecificationData> PartSpecification { get; set; } = default!;
        public DbSet<PartData> Parts { get; set; } = default!;
        public DbSet<PartSpecificationStatusData> PartSpecificationStatus { get; set; } = default!;
        public DbSet<PartSpecificationRoleData> PartSpecificationRole { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        internal static void InitializeTables(ModelBuilder builder)
        {
            ToTable<PartSpecificationData>(builder, nameof(PartSpecification), _projectSchema);
            //var type = ToTable<PartSpecificationData>(builder, nameof(PartSpecification), _contosoSchema);
            //SetType(type, x => x.Budget, _decimal);
            ToTable<PartData>(builder, nameof(Parts), _projectSchema);
            ToTable<PartSpecificationStatusData>(builder, nameof(PartSpecificationStatus), _projectSchema);
            ToTable<PartSpecificationRoleData>(builder, nameof(PartSpecificationRole), _projectSchema);

            //var s = _projectSchema;
            //toTable<StudentData>(b, nameof(Students), s);
            //toTable<InstructorData>(b, nameof(Instructors), s);
            //var t = toTable<DepartmentData>(b, nameof(Departments), s);
            //setType(t, x => x.Budget, fourDecimals);
            //toTable<CourseData>(b, nameof(Courses), s);
            //toTable<EnrollmentData>(b, nameof(Enrollments), s);
            //var c = toTable<AssignmentData>(b, nameof(Assignments), s);
            //c.HasAlternateKey(nameof(AssignmentData.CourseId), nameof(AssignmentData.InstructorId));

        }
    }
}
