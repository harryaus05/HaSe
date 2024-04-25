namespace HaSe.Domain.Common {
    public interface IOrderedRepo<TEntity> : IFilteredRepo<TEntity> where TEntity : class {
        string SortOrder { get; set; }
    }
}
