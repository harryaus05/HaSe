using HaSe.Data.Contoso;
using HaSe.Domain.Contoso;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Contoso
{
    public class DepartmentsRepo(ContosoDbContext context) : Repo<Department,DepartmentData>(context, context.Department), IDepartmentsRepo
    {
        protected override IQueryable<DepartmentData> AddSearchString(IQueryable<DepartmentData> sql)
        {
            return string.IsNullOrEmpty(SearchString) ? sql
                : sql.Where(s => s.Name != null
                                 && (s.Name.Contains(SearchString)
                                     || s.Budget.ToString().Contains(SearchString)
                                     || s.StartDate.ToString().Contains(SearchString))
                                     || s.InstructorId.ToString().Contains(SearchString));
        }

        protected override Department ToEntity(DepartmentData? data) {
            return new Department(data);
        }
    }
}
