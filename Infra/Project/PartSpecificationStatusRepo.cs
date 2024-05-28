using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project {
    public class PartSpecificationStatusRepo(ProjectDbContext context) : 
        Repo<PartSpecificationStatus, PartSpecificationStatusData>(context, context.PartSpecificationStatus), IPartSpecificationStatusRepo {

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
        //protected override IQueryable<PartSpecificationStatusData> addFixedFilter(IQueryable<PartSpecificationStatusData> sql) =>
        //    (FixedFilter == nameof(PartSpecificationStatusData.PartSpecificationId)) ? sql.Where(s => s.PartSpecificationId.ToString() == SearchString)
        //    //: (FixedFilter == nameof(EnrollmentData.CourseId)) ? sql.Where(s => s.CourseId.ToString() == SearchString)
        //    : sql;
    }
}
