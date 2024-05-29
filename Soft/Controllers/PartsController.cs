using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class PartsController(IPartsRepo repo) : BaseController<Part, PartViewModel>(repo) {
        protected override string selectItemTextField => nameof(PartViewModel.Name);
        protected override Part toModel(PartViewModel viewmodel) {
            return new (Copy.Members<PartViewModel, PartData>(viewmodel));
        }

        //protected override PartViewModel ToViewModel(Part model) {
        //    var viewModel = base.ToViewModel(model);
        //    viewModel.Name = "model.ToString()";
        //    return viewModel;
        //}
        protected override async Task<PartViewModel> toViewAsync(Part m) {
            if (loadlazy) await m.LoadLazy();
            var v = await base.toViewAsync(m);
            v.PartSpecifications = m?.PartSpecifications?.Select(Copy.Members<PartSpecification, PartSpecificationViewModel>).ToList();
            return v;
        }
    }

}
