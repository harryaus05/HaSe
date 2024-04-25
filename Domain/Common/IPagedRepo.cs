namespace HaSe.Domain.Common {
    public interface IPagedRepo<TEntity>: IOrderedRepo<TEntity> where TEntity : class {
        int? PageNumber { get; set; }
        int Page { get; }
        int PageSize { get; set; }
        int TotalPages { get; }
        int TotalItems { get; }
        bool HasNextPage { get; }
        bool HasPreviousPage { get; }
    }
}
