using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HaSe.Infra.Project;

namespace HaSe.Soft.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options) {
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            ProjectDbContext.InitializeTables(builder);
        }
    }
}