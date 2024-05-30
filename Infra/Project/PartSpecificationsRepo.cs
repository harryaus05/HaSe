using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project
{
    public class PartSpecificationsRepo(ProjectDbContext context) :
        Repo<PartSpecification,PartSpecificationData>(context, context.PartSpecification), IPartSpecificationRepo
    {
        protected internal override string selectTextField => nameof(PartSpecificationData.Description);
        protected override IQueryable<PartSpecificationData> addSearch(IQueryable<PartSpecificationData> sql)
        {
            return string.IsNullOrWhiteSpace(SearchString) ? sql
                : sql.Where(s => s.Description != null
                                 && (s.Description.Contains(SearchString)
                                     || s.Type.Contains(SearchString)
                                     || s.DateDocumented.ToString().Contains(SearchString))
                                     || s.Comment.Contains(SearchString)
                                     || s.PartId.ToString().Contains(SearchString));
        }

        protected override PartSpecification ToEntity(PartSpecificationData? d) => new(d);
        protected override IQueryable<PartSpecificationData> addFixedFilter(IQueryable<PartSpecificationData> sql) =>
            (FixedFilter == nameof(PartSpecificationData.PartId)) ? sql.Where(s => s.PartId.ToString() == FixedValue)
                : sql;
       
    }
}
