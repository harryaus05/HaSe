using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class PartSpecificationStatusController(IPartSpecificationStatusRepo repo, IPartSpecificationsRepo? partsRepo = null) : BaseController<PartSpecificationStatus, PartSpecificationStatusViewModel>(repo) {

        protected override string selectItemTextField => nameof(PartSpecificationStatusViewModel.FromDate);
        protected override PartSpecificationStatus ToModel(PartSpecificationStatusViewModel viewmodel) {
            return new PartSpecificationStatus(PropertyCopier.CopyPropertiesFrom<PartSpecificationStatusViewModel, PartSpecificationStatusData>(viewmodel));
        }

        protected override async Task PopulateRelatedItems(PartSpecificationStatus? model) {
            await base.PopulateRelatedItems(model);
            if(partsRepo is null)
                return;
            ViewBag.Parts = await new PartSpecificationController(partsRepo).SelectListAsync();
        }
    }
}
