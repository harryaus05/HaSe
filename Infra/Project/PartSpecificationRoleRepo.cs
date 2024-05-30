using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project
{
    public class PartSpecificationRoleRepo(ProjectDbContext c) :
        Repo<PartSpecificationRole, PartSpecificationRoleData>(c, c.PartSpecificationRole), IPartSpecificationRoleRepo {
        protected override IQueryable<PartSpecificationRoleData> addSearch(IQueryable<PartSpecificationRoleData> sql)
        {
            return string.IsNullOrWhiteSpace(SearchString) ? sql
                : sql.Where(s => s.PartyName != null
                    && (s.PartyName.Contains(SearchString)
                    || s.Type.Contains(SearchString)
                    || s.PartSpecificationId.ToString().Contains(SearchString)));
        }

        protected override PartSpecificationRole ToEntity(PartSpecificationRoleData? d) {
            return new PartSpecificationRole(d);
        }
        protected override IQueryable<PartSpecificationRoleData> addFixedFilter(IQueryable<PartSpecificationRoleData> sql) =>
            (FixedFilter == nameof(PartSpecificationRoleData.PartSpecificationId)) ? sql.Where(s => s.PartSpecificationId.ToString() == FixedValue)
                : sql;


    }
}
