using HaSe.Data.Contoso;
using HaSe.Helpers.Methods;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project.DbInitializers;

public sealed class DepartmentDbInitializer(DbContext db, DbSet<DepartmentData> set) : DbInitializer<DepartmentData>(db, set)
{
    protected override void SetValues(int index)
    {
        if (Item == null)
            return;
        Item.Name = $"Department {index} name";
        Item.Budget = 1000000 * index;
        Item.InstructorId = index;
        Item.StartDate = GetRandom.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));

    }
}