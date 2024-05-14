using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project {
    public class PartSpecificationStatusRepo(ProjectDbContext context) : Repo<PartSpecificationStatus, PartSpecificationStatusData>(context, context.PartSpecificationStatus), IPartSpecificationStatusRepo {

        protected override IQueryable<PartSpecificationStatusData> addFilter(IQueryable<PartSpecificationStatusData> sql) {
            return string.IsNullOrWhiteSpace(SearchString)
                ? sql
                : sql.Where(s => s.FromDate.ToString().Contains(SearchString)
                                 && (s.FromDate.ToString().Contains(SearchString))
                                 || s.ThruDate.ToString().Contains(SearchString)
                                 || s.PartSpecificationId.ToString().Contains(SearchString)
                                 || s.Type.Contains(SearchString));
        }
        protected override PartSpecificationStatus ToEntity(PartSpecificationStatusData? d) => new(d);
        protected override IQueryable<PartSpecificationStatusData> addFixedFilter(IQueryable<PartSpecificationStatusData> sql) =>
         (FixedFilter == nameof(PartSpecificationStatusData.PartSpecificationId)) ? sql.Where(s => s.PartSpecificationId.ToString() == SearchString)
        : sql;

    }
}
