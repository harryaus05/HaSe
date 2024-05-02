using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace HaSe.Infra.Project {
    public class PartSpecificationStatusRepo(ProjectDbContext context) : Repo<PartSpecificationStatus, PartSpecificationStatusData>(context, context.PartSpecificationStatus), IPartSpecificationStatusRepo {

        protected override IQueryable<PartSpecificationStatusData> AddSearchString(IQueryable<PartSpecificationStatusData> sql) {
            return string.IsNullOrEmpty(SearchString) ? sql
                : sql.Where(s => s.FromDate != null
                                 && (s.FromDate.ToString().Contains(SearchString))
                                     || s.ThruDate.ToString().Contains(SearchString));

        }


        protected override PartSpecificationStatus ToEntity(PartSpecificationStatusData? data) {
            throw new NotImplementedException();
        }
    }
}
