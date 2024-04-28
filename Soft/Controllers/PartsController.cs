using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    //public class PartsController(IPartsRepo repo, IPartSpecificationsRepo partSpecificationsRepo) : BaseController<Part, PartViewModel>(repo) {
    //    protected override Part ToModel(PartViewModel viewmodel) {
    //        return new Part(PropertyCopier.CopyPropertiesFrom<PartViewModel, PartData>(viewmodel));
    //    }

    //    protected override async Task PopulateRelatedItems(Part? model) {
    //        await base.PopulateRelatedItems(model);
    //        ViewBag.Parts = await new PartSpecificationController(partSpecificationsRepo, null).SelectListAsync();
    //    }
    //}

    public class PartsController(IPartsRepo repo) : BaseController<Part, PartViewModel>(repo) {
        protected override string selectItemTextField => nameof(PartViewModel.Name);
        protected override Part ToModel(PartViewModel viewmodel) {
            return new Part(PropertyCopier.CopyPropertiesFrom<PartViewModel, PartData>(viewmodel));
        }

        //protected override PartViewModel ToViewModel(Part model) {
        //    var viewModel = base.ToViewModel(model);
        //    viewModel.Name = "model.ToString()";
        //    return viewModel;
        //}
    }
}
