using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HaSe.Infra {
    public abstract class BaseDbContext<TDbContext>(DbContextOptions<TDbContext> options) : DbContext(options) where TDbContext : DbContext {
        protected static EntityTypeBuilder<TEntity> ToTable<TEntity>(ModelBuilder builder, string name, string schema) where TEntity : class {
            return builder.Entity<TEntity>().ToTable(name, schema);
        }

        protected static void SetType<TEntity>(EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, object>> expression, string type) where TEntity : class {
            builder.Property(expression).HasColumnType(type);
        }
    }
}
