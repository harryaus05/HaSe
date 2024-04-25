using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class PagedRepo<TEntity, TData>(DbContext context, DbSet<TData> s) : 
        OrderedRepo<TEntity, TData>(context, s), IPagedRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() {
        public int? PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
        public int Page => PageNumber == 0 ? TotalPages : PageNumber ?? 1;
        public int TotalPages => (int)Math.Ceiling(TotalItems/(double)PageSize);
        public int TotalItems => base.CreateSql().Count();
        public bool HasPreviousPage => Page > 1;
        public bool HasNextPage => Page < TotalPages;

        protected internal override IQueryable<TData> CreateSql() {
            var sql = base.CreateSql();
            sql = sql.Skip((Page - 1) * PageSize).Take(PageSize);
            return sql;
        }
    }
}
