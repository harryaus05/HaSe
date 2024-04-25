using HaSe.Data.Contoso;
using HaSe.Domain.Contoso;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Contoso
{
    public class CoursesRepo(ContosoDbContext context) : Repo<Course, CourseData>(context, context.Courses), ICoursesRepo
    {
        protected override IQueryable<CourseData> AddSearchString(IQueryable<CourseData> sql)
        {
            return string.IsNullOrEmpty(SearchString) ? sql
                : sql.Where(s => s.Title != null
                    && (s.Title.Contains(SearchString)
                    || s.Credits.ToString().Contains(SearchString)
                    || s.DepartmentId.ToString().Contains(SearchString)));
        }

        protected override Course ToEntity(CourseData? data) {
            return new Course(data);
        }
    }
}
