using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class PartSpecificationController(IPartSpecificationRepo repo, IPartsRepo? partsRepo = null) : BaseController<PartSpecification, PartSpecificationViewModel>(repo) {
        protected override string selectItemTextField => nameof(PartSpecificationViewModel.Description);
        //protected override PartSpecification ToModel(PartSpecificationViewModel viewmodel) {
        //    return new PartSpecification(PropertyCopier.CopyPropertiesFrom<PartSpecificationViewModel, PartSpecificationData>(viewmodel));
        //}

        protected override async Task PopulateRelatedItems(PartSpecification? model) {
            await base.PopulateRelatedItems(model);
            if (partsRepo is null)
                return;
            ViewBag.Parts = await new PartsController(partsRepo).SelectListAsync();
        }

        protected override PartSpecification ToModel(PartSpecificationViewModel v) => new(Copy.Members<PartSpecificationViewModel, PartSpecificationData>(v));
        protected override async Task<PartSpecificationViewModel> ToViewAsync(PartSpecification m) {
            if (loadlazy) await m.LoadLazy();
            var v = await base.ToViewAsync(m);
            v.SpecificationStatus = m?.SpecificationStatus?.Select(Copy.Members<PartSpecificationStatus, PartSpecificationStatusViewModel>).ToList();
            
            return v;
        }
    }
}
