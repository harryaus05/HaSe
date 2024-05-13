using HaSe.Domain.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HaSe.Domain {
    public static class GetFromRepo {
        private static IServiceCollection? services;
        public static void SetServices(IServiceCollection s) => services = s;
        private static TRepo? repo<TRepo, TEntity>() where TRepo : IRepo<TEntity> where TEntity : class {
            var p = services?.BuildServiceProvider();
            return p is null ? default : p.GetRequiredService<TRepo>();
        }
        public static async Task<TEntity?> Item<TRepo, TEntity>(int id) where TRepo : IRepo<TEntity> where TEntity : class {
            var r = repo<TRepo, TEntity>();
            return r is null ? null : await r.GetAsync(id);
        }

        internal static async Task<List<TEntity>?> Items<TRepo, TEntity>(string property, int value)
            where TRepo : IRepo<TEntity> where TEntity : class {
            var r = repo<TRepo, TEntity>();
            if (r is null) return null;
            r.SearchString = value.ToString();
            r.FixedFilter = property;
            r.PageSize = r.TotalItems;
            var l = await r.GetAsync();
            return l.ToList();
        }
    }
}
