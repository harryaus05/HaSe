using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class CrudRepo<TEntity, TData>(DbContext context, DbSet<TData> set) : BaseRepo, ICrudRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() {
        internal readonly DbContext _db = context;
        internal readonly DbSet<TData> _set = set;
        internal TEntity? _item;
        internal readonly List<TEntity> _list = [];
        protected internal virtual IQueryable<TData> CreateSql() => from s in _set select s;

        public async Task<bool> AddAsync(TEntity obj) {
            try {
                await _set.AddAsync(obj.Data);
                await _db.SaveChangesAsync();
                return true;
            }
            catch {
                _db.ChangeTracker.Clear();
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id) {
            try {
                var entity = await FindAsyncData(id);
                if (entity != null) {
                    _set.Remove(entity);
                }

                await _db.SaveChangesAsync();
                return true;
            }
            catch {
                _db.ChangeTracker.Clear();
                return false;
            }
        }

        public async Task<TEntity?> FindAsync(int? id) {
            return ToEntity(await FindAsyncData(id));
        }

        public async Task<TData?> FindAsyncData(int? id) {
            return await _set.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync() {
            return (await GetAsyncData()).Select(ToEntity);
        }

        public async Task<IEnumerable<TData>> GetAsyncData() {
            return await CreateSql().AsNoTracking().ToListAsync();
        }

        protected abstract TEntity ToEntity(TData? data);

        public async Task<TEntity?> GetAsync(int? id) {
            return ToEntity(await GetAsyncData(id));
        }

        public async Task<TData?> GetAsyncData(int? id) {
            return await _set.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> UpdateAsync(TEntity obj) {
            if (!IsInDbSet(obj.Id))
                return false;
            try {
                _set.Update(obj.Data);
                await _db.SaveChangesAsync();
                return true;
            }
            catch {
                _db.ChangeTracker.Clear();
                return false;
            }
        }

        protected bool IsInDbSet(int id) {
            return _set.Any(e => e.Id == id);
        }
    }
}
