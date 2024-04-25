using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class FilteredRepo<TEntity, TData>(DbContext context, DbSet<TData> set) : 
        CrudRepo<TEntity, TData>(context, set), IFilteredRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() {
        public string SearchString { get; set; } = string.Empty;

        protected internal override IQueryable<TData> CreateSql() {
            var sql = base.CreateSql();
            sql = AddSearchString(sql);
            return sql;
        }

        protected abstract IQueryable<TData> AddSearchString(IQueryable<TData> sql);
    }
}
