using HaSe.Data.Contoso;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Contoso;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class StudentController(IStudentsRepo repo) : BaseController<Student, StudentViewModel>(repo) {
        protected override Student ToModel(StudentViewModel viewmodel) {
            return new Student(PropertyCopier.CopyPropertiesFrom<StudentViewModel, StudentData>(viewmodel));
        }
    }
}
