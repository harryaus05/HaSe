using HaSe.Data.Project;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project
{
    public class ContosoDbContext(DbContextOptions<ContosoDbContext> options) : BaseDbContext<ContosoDbContext>(options)
    {
        internal const string _contosoSchema = "Contoso";
        internal const string _decimal = "decimal(16,4)";
        public DbSet<StudentData> Student { get; set; } = default!;
        public DbSet<InstructorData> Instructor { get; set; } = default!;
        public DbSet<PartSpecificationData> PartSpecification { get; set; } = default!;
        public DbSet<PartData> Parts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            ToTable<StudentData>(builder, nameof(Student), _contosoSchema);
            ToTable<InstructorData>(builder, nameof(Instructor), _contosoSchema);
            ToTable<PartSpecificationData>(builder, nameof(PartSpecification), _contosoSchema);
            //var type = ToTable<PartSpecificationData>(builder, nameof(PartSpecification), _contosoSchema);
            //SetType(type, x => x.Budget, _decimal);
            ToTable<PartData>(builder, nameof(Parts), _contosoSchema);
        }
    }
}
