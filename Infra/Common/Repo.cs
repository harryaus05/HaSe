using HaSe.Data;
using HaSe.Domain;
using HaSe.Domain.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Common {
    public abstract class Repo<TEntity, TData>(DbContext c, DbSet<TData> s) :
        PagedRepo<TEntity, TData>(c, s),
        IRepo<TEntity> where TEntity : Entity<TData> where TData : EntityData, new() {
        protected internal virtual string selectTextField => nameof(EntityData.Id);

        public async Task<dynamic?> SelectItem(int id) {
            var l = await selectList(id);
            return l.FirstOrDefault();
        }
        public async Task<IEnumerable<dynamic>> SelectItems(string researchString, int id) {
            PageNumber = 1;
            SearchString = researchString;
            SortOrder = selectTextField;
            var l = (await getAsync()).ToList();
            return await selectList(id, l);
        }
        private async Task<SelectList> selectList(int id, List<TData>? l = null) {
            var list = l ?? [];
            var o = await getAsync(id);
            if (o != null && !list.Contains(o)) list.Add(o);
            return new SelectList(list, nameof(EntityData.Id), selectTextField, id);
        }
    }
}
