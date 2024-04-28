using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class PartsController(IPartsRepo repo, IPartSpecificationsRepo partSpecificationsRepo) : BaseController<Part, PartViewModel>(repo) {
        protected override Part ToModel(PartViewModel viewmodel) {
            return new Part(PropertyCopier.CopyPropertiesFrom<PartViewModel, PartData>(viewmodel));
        }

        protected override async Task PopulateRelatedItems(Part? model) {
            await base.PopulateRelatedItems(model);
            ViewBag.Departments = await new PartSpecificationController(partSpecificationsRepo, null).SelectListAsync();
        }
    }
}
