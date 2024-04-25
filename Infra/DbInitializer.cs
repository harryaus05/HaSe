using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra {
    public abstract class DbInitializer<TItem>(DbContext db, DbSet<TItem> set) where TItem : class, new() {
        private readonly DbContext _db = db;
        private readonly DbSet<TItem> _set = set;
        protected TItem? Item;
        private readonly List<TItem> _list = [];

        protected abstract void SetValues(int index);

        private async Task Save() {
            await _set.AddRangeAsync(_list);
            await _db.SaveChangesAsync();
            _list.Clear();
        }

        private bool CanInitialize() {
            if (_db is null)
                return false;
            if (_set is null)
                return false;
            _db.Database.EnsureCreated();
            return !_set.Any();
        }

        public async Task Initialize(uint count) {
            if (!CanInitialize())
                return;
            try {
                for (var i = 1; i < count; i++) {
                    Item = new TItem();
                    SetValues(i);
                    _list.Add(Item);
                    if (i % 100 != 0) continue;
                    await Save();
                }
            }
            finally {
                await Save();
            }
        }
    }
}

