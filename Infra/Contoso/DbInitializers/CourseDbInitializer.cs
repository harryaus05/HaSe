using HaSe.Data.Contoso;
using HaSe.Helpers.Methods;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Contoso.DbInitializers;

public sealed class CourseDbInitializer(DbContext db, DbSet<CourseData> set) : DbInitializer<CourseData>(db, set)
{
    protected override void SetValues(int index)
    {
        if (Item == null)
            return;
        Item.Title = $"Course {index} title";
        Item.Credits = GetRandom.Bool() ? 6 : 12;
        Item.DepartmentId = index % 100 + 1;
    }
}