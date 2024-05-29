using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project {
    public class PartSpecificationStatusRepo(ProjectDbContext context) : 
        Repo<PartSpecificationStatus, PartSpecificationStatusData>(context, context.PartSpecificationStatus), IPartSpecificationStatusRepo {
        protected internal override string selectTextField => nameof(PartSpecification.Description);
        protected override IQueryable<PartSpecificationStatusData> addSearch(IQueryable<PartSpecificationStatusData> sql) {
            return string.IsNullOrEmpty(SearchString)
                ? sql
                : sql.Where(s => (s.FromDate != null
                                 && (s.FromDate.ToString().Contains(SearchString))
                                 || s.ThruDate.ToString().Contains(SearchString)
                                 || s.PartSpecificationId.ToString().Contains(SearchString)
                                 || s.Type.Contains(SearchString)));
        }
        protected override PartSpecificationStatus ToEntity(PartSpecificationStatusData? data) => new(data);
    }
}
