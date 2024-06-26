﻿using HaSe.Data.Project;
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
            ToTable<PartData>(builder, nameof(Parts), _projectSchema);
            ToTable<PartSpecificationStatusData>(builder, nameof(PartSpecificationStatus), _projectSchema);
            ToTable<PartSpecificationRoleData>(builder, nameof(PartSpecificationRole), _projectSchema);
        }
    }
}
