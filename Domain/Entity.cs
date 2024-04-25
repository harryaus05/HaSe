using HaSe.Data;
using HaSe.Helpers.Methods;

namespace HaSe.Domain {
    public abstract class Entity<TData>(TData? data) where TData : EntityData, new() {
        internal readonly TData _data = data ?? new TData();
        public TData Data => PropertyCopier.CopyPropertiesFrom<TData, TData>(_data);
        public int Id => _data.Id;
    }
}
