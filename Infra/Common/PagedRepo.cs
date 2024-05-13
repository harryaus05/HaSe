using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class PagedRepo<TEntity, TData>(DbContext c, DbSet<TData> s) :
        OrderedRepo<TEntity, TData>(c, s),
        IPagedRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() {
        public int? PageNumber { get; set; }
        public int PageNumberAsInt => PageNumber == 0 ? TotalPages : PageNumber ?? 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public int TotalItems => base.createSQL().Count();
        public bool HasPreviousPage => PageNumberAsInt > 1;
        public bool HasNextPage => PageNumberAsInt < TotalPages;
        protected internal override IQueryable<TData> createSQL() {
            var sql = base.createSQL();
            sql = sql.Skip((PageNumberAsInt - 1) * PageSize).Take(PageSize);
            return sql;
        }
    }
}
