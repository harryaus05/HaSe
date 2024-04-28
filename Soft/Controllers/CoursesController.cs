using HaSe.Data.Contoso;
using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Contoso;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class CoursesController(IPartsRepo repo, IDepartmentsRepo departmentsRepo) : BaseController<Part, CourseViewModel>(repo) {
        protected override Part ToModel(CourseViewModel viewmodel) {
            return new Part(PropertyCopier.CopyPropertiesFrom<CourseViewModel, PartData>(viewmodel));
        }

        protected override async Task PopulateRelatedItems(Part? model) {
            await base.PopulateRelatedItems(model);
            ViewBag.Departments = await new DepartmentController(departmentsRepo, null).SelectListAsync();
        }
    }
}
