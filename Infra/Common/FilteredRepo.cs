using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class FilteredRepo<TEntity, TData>(DbContext c, DbSet<TData> s) :
        CrudRepo<TEntity, TData>(c, s), IFilteredRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() {
        public string SearchString { get; set; } = string.Empty;
        public string? FixedFilter { get; set; }
        public string? FixedValue { get; set; }

        protected internal override IQueryable<TData> createSQL() {
            var sql = base.createSQL();
            sql = addSearch(sql);
            sql = addFixedFilter(sql);
            return sql;
        }
        protected virtual IQueryable<TData> addFixedFilter(IQueryable<TData> sql) => sql;
        protected abstract IQueryable<TData> addSearch(IQueryable<TData> sql);
    }
}
