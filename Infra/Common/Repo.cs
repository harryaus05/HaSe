using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class Repo<TEntity, TData>(DbContext context, DbSet<TData> set) : 
        PagedRepo<TEntity, TData>(context, set), IPagedRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() { }
}
