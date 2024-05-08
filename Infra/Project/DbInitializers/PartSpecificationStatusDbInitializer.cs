using HaSe.Data.Project;
using HaSe.Helpers.Methods;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project.DbInitializers {
    public class PartSpecificationStatusDbInitializer(DbContext db, DbSet<PartSpecificationStatusData> set) : DbInitializer<PartSpecificationStatusData>(db, set) {
        protected override void SetValues(int index) {
            if(Item == null)
                return;
            Item.FromDate = GetRandom.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-1));
            Item.ThruDate = GetRandom.DateTime(DateTime.Now.AddYears(1), DateTime.Now.AddYears(10));
            Item.Type = $"PartSpecification Status {index} type";
        }
    }
}
