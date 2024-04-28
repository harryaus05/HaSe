using HaSe.Data.Contoso;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project {
    public class StudentsRepo(ContosoDbContext context) : Repo<Student, StudentData>(context, context.Student), IStudentsRepo {
        protected override IQueryable<StudentData> AddSearchString(IQueryable<StudentData> sql) {
            return string.IsNullOrEmpty(SearchString) ? sql : 
                sql.Where(s => s.LastName != null && (s.LastName.Contains(SearchString) 
                    || s.FirstName != null && s.FirstName.Contains(SearchString) 
                    || s.EnrollmentDate.ToString().Contains(SearchString)));
        }

        protected override Student ToEntity(StudentData? data) {
            return new Student(data);
        }
    }
}
