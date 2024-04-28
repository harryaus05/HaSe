using HaSe.Data.Project;
using HaSe.Helpers.Methods;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project.DbInitializers;

public sealed class PartSpecificationDbInitializer(DbContext db, DbSet<PartSpecificationData> set) : DbInitializer<PartSpecificationData>(db, set)
{
    protected override void SetValues(int index)
    {
        if (Item == null)
            return;
        Item.Description = $"PartSpecification {index} name";
        Item.Type = $"PartSpecification {index} type";
        Item.DateDocumented = GetRandom.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));
        Item.Comment = $"PartSpecification {index} comment";
        Item.PartId = index;

    }
}