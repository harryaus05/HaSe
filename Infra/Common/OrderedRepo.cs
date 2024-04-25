using System.Linq.Expressions;
using System.Reflection;
using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class OrderedRepo<TEntity, TData>(DbContext context, DbSet<TData> set) : 
        FilteredRepo<TEntity, TData>(context, set), IOrderedRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() {
        public string SortOrder { get; set; } = string.Empty;
        internal static string _descendingString => "_desc";
        internal string? _propertyName => SortOrder?.Replace(_descendingString, string.Empty);
        internal PropertyInfo? _propertyInfo => typeof(TData).GetProperty(_propertyName ?? string.Empty);
        protected internal override IQueryable<TData> CreateSql() {
            var sql = base.CreateSql();
            var keySelector = CreateKeySelector();
            return AddOrderBy(sql, keySelector);
        }

        internal IQueryable<TData> AddOrderBy(IQueryable<TData> sql, Expression<Func<TData, object>>? keySelector) {
            if (keySelector is null)
                return sql;
            return IsDescending ? sql.OrderByDescending(keySelector) : sql.OrderBy(keySelector);
        }

        internal bool IsDescending => SortOrder.EndsWith(_descendingString);

        private Expression<Func<TData, object>>? CreateKeySelector() {
            var propertyInfo = _propertyInfo;
            if (propertyInfo is null)
                return null;
            var parameter = Expression.Parameter(typeof(TData), "x");
            var property = Expression.Property(parameter, propertyInfo);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TData, object>>(body, parameter);
        }
    }
}
