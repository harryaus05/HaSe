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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            ToTable<PartSpecificationData>(builder, nameof(PartSpecification), _projectSchema);
            //var type = ToTable<PartSpecificationData>(builder, nameof(PartSpecification), _contosoSchema);
            //SetType(type, x => x.Budget, _decimal);
            ToTable<PartData>(builder, nameof(Parts), _projectSchema);
        }
    }
}
