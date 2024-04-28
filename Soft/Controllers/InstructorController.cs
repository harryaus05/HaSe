using HaSe.Data.Contoso;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class InstructorController(IInstructorsRepo repo) : BaseController<Instructor, InstructorViewModel>(repo) {
        protected override string selectItemTextField => nameof(InstructorViewModel.FullName);
        protected override Instructor ToModel(InstructorViewModel viewmodel) {
            return new Instructor(PropertyCopier.CopyPropertiesFrom<InstructorViewModel, InstructorData>(viewmodel));
        }

        protected override InstructorViewModel ToViewModel(Instructor model) {
            var viewModel = base.ToViewModel(model);
            viewModel.FullName = model.ToString();
            return viewModel;
        }
    }
}
