using HaSe.Data.Project;
using HaSe.Helpers.Methods;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project.DbInitializers {
    public class PartSpecificationRoleDbInitializer(DbContext db, DbSet<PartSpecificationRoleData> set) : DbInitializer<PartSpecificationRoleData>(db, set) {
        protected override void SetValues(int index) {
            if(Item == null)
                return;
            Item.PartyName = $"PartSpecification Role {index} name";
            Item.Type = $"PartSpecification Role {index} type";
        }
    }
}
