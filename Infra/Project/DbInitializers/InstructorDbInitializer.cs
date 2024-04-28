using HaSe.Data.Contoso;
using HaSe.Helpers.Methods;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project.DbInitializers;

public sealed class InstructorDbInitializer(DbContext db, DbSet<InstructorData> set) : DbInitializer<InstructorData>(db, set)
{
    protected override void SetValues(int index)
    {
        if (Item == null)
            return;
        Item.FirstName = GetRandom.String();
        Item.LastName = GetRandom.String();
        Item.HireDate = GetRandom.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));
    }
}