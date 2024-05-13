using System.Linq.Expressions;
using System.Reflection;
using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class OrderedRepo<TEntity, TData>(DbContext c, DbSet<TData> s) :
        FilteredRepo<TEntity, TData>(c, s),
        IOrderedRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() {
        public string SortOrder { get; set; } = string.Empty;
        internal static string descendingStr => "_desc";
        internal string? propertyName => SortOrder?.Replace(descendingStr, string.Empty);
        internal PropertyInfo? propertyInfo => typeof(TData).GetProperty(propertyName ?? string.Empty);

        protected internal override IQueryable<TData> createSQL() {
            var sql = base.createSQL();
            var keySelector = createKeySelector();
            return addOrderBy(sql, keySelector);
        }
        private Expression<Func<TData, object>>? createKeySelector() {
            var pi = propertyInfo;
            if (pi is null) return null;
            var param = Expression.Parameter(typeof(TData), "x");
            var property = Expression.Property(param, pi);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TData, object>>(body, param);
        }
        internal IQueryable<TData> addOrderBy(IQueryable<TData> sql, Expression<Func<TData, object>>? keySelector) {
            if (keySelector is null) return sql;
            if (isDescending) return sql.OrderByDescending(keySelector);
            else return sql.OrderBy(keySelector);
        }
        internal bool isDescending => SortOrder.EndsWith(descendingStr);
    }
}
