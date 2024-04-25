using HaSe.Data.Contoso;
using HaSe.Domain.Contoso;
using HaSe.Domain.Repos;
using HaSe.Facade.Contoso;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class CoursesController(ICoursesRepo repo, IDepartmentsRepo departmentsRepo) : BaseController<Course, CourseViewModel>(repo) {
        protected override Course ToModel(CourseViewModel viewmodel) {
            return new Course(PropertyCopier.CopyPropertiesFrom<CourseViewModel, CourseData>(viewmodel));
        }

        protected override async Task PopulateRelatedItems(Course? model) {
            await base.PopulateRelatedItems(model);
            ViewBag.Departments = await new DepartmentController(departmentsRepo, null).SelectListAsync();
        }
    }
}
