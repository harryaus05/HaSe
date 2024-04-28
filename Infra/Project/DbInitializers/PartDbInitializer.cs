using HaSe.Data.Project;
using HaSe.Helpers.Methods;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project.DbInitializers;

public sealed class PartDbInitializer(DbContext db, DbSet<PartData> set) : DbInitializer<PartData>(db, set)
{
    protected override void SetValues(int index)
    {
        if (Item == null)
            return;
        Item.Name = $"Part {index} title";
        //Item.Credits = GetRandom.Bool() ? 6 : 12;
        Item.DepartmentId = index % 100 + 1;
    }
}