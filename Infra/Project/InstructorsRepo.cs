using HaSe.Data.Contoso;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project
{
    public class InstructorsRepo(ContosoDbContext context) : Repo<Instructor, InstructorData>(context, context.Instructor), IInstructorsRepo
    {
        protected override IQueryable<InstructorData> AddSearchString(IQueryable<InstructorData> sql)
        {
            return string.IsNullOrEmpty(SearchString) ? sql
                : sql.Where(s => s.LastName != null
                                 && (s.LastName.Contains(SearchString)
                                     || s.FirstName != null && s.FirstName.Contains(SearchString)
                                     || s.HireDate.ToString().Contains(SearchString)));
        }

        protected override Instructor ToEntity(InstructorData? data) {
            return new Instructor(data);
        }
    }
}
