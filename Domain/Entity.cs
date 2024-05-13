using HaSe.Data;
using HaSe.Helpers.Methods;

namespace HaSe.Domain {
    public abstract class Entity<TData>(TData? d) where TData : EntityData, new() {
        internal readonly TData data = d ?? new TData();
        public async virtual Task LoadLazy() { await Task.CompletedTask; }
        public TData Data => Copy.Members<TData, TData>(data);
        public int Id => data.Id;
    }
}
