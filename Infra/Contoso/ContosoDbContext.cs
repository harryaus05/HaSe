using HaSe.Data.Contoso;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Contoso
{
    public class ContosoDbContext(DbContextOptions<ContosoDbContext> options) : BaseDbContext<ContosoDbContext>(options)
    {
        internal const string _contosoSchema = "Contoso";
        internal const string _decimal = "decimal(16,4)";
        public DbSet<StudentData> Student { get; set; } = default!;
        public DbSet<InstructorData> Instructor { get; set; } = default!;
        public DbSet<DepartmentData> Department { get; set; } = default!;
        public DbSet<CourseData> Courses { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            ToTable<StudentData>(builder, nameof(Student), _contosoSchema);
            ToTable<InstructorData>(builder, nameof(Instructor), _contosoSchema);
            var type = ToTable<DepartmentData>(builder, nameof(Department), _contosoSchema);
            SetType(type, x => x.Budget, _decimal);
            ToTable<CourseData>(builder, nameof(Courses), _contosoSchema);
        }
    }
}
