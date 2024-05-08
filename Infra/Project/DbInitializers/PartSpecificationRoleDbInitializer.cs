using HaSe.Data.Project;
using HaSe.Helpers.Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
