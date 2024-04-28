using HaSe.Data.Contoso;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Contoso;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class DepartmentController(IDepartmentsRepo repo, IInstructorsRepo? instructorsRepo = null) : BaseController<Department, DepartmentViewModel>(repo) {
        protected override string selectItemTextField => nameof(DepartmentViewModel.Name);
        protected override Department ToModel(DepartmentViewModel viewmodel) {
            return new Department(PropertyCopier.CopyPropertiesFrom<DepartmentViewModel, DepartmentData>(viewmodel));
        }

        protected override async Task PopulateRelatedItems(Department? model) {
            await base.PopulateRelatedItems(model);
            if (instructorsRepo is null)
                return;
            ViewBag.Instructors = await new InstructorController(instructorsRepo).SelectListAsync();
        }
    }
}
