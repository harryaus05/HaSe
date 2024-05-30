using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class PartSpecificationController(IPartSpecificationRepo repo, IPartsRepo? partsRepo = null) : BaseController<PartSpecification, PartSpecificationViewModel>(repo) {
        protected override string selectItemTextField => nameof(PartSpecificationViewModel.Description);
        protected override PartSpecification toModel(PartSpecificationViewModel v) => new(Copy.Members<PartSpecificationViewModel, PartSpecificationData>(v));
        protected override async Task<PartSpecificationViewModel> toViewAsync(PartSpecification m) {
            if (loadlazy) await m.LoadLazy();
            var v = await base.toViewAsync(m);
            v.SpecificationStatus = m?.SpecificationStatus?.Select(Copy.Members<PartSpecificationStatus, PartSpecificationStatusViewModel>).ToList();
            v.SpecificationRole = m?.SpecificationRole?.Select(Copy.Members<PartSpecificationRole, PartSpecificationRoleViewModel>).ToList();

            return v;
        }
    }
}
