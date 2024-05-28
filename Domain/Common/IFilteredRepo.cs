namespace HaSe.Domain.Common {
    public interface IFilteredRepo<TEntity> : ICrudRepo<TEntity> where TEntity : class {
        string SearchString { get; set; }
        string? FixedFilter { get; set; }
        string? FixedValue { get; set; }
    }
}
