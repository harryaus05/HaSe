using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class PartSpecificationStatusController(IPartSpecificationStatusRepo repo) : BaseController<PartSpecificationStatus, PartSpecificationStatusViewModel>(repo) {

        protected override PartSpecificationStatus toModel(PartSpecificationStatusViewModel v) => new(Copy.Members<PartSpecificationStatusViewModel, PartSpecificationStatusData>(v));
        protected override string selectItemTextField => nameof(PartSpecificationStatusViewModel.FromDate);
        protected override async Task<PartSpecificationStatusViewModel> toViewAsync(PartSpecificationStatus m) {
            if (loadlazy) await m.LoadLazy();
            var v = await base.toViewAsync(m);
            v.PartSpecification = m?.PSpecification?.Select(Copy.Members<PartSpecification, PartSpecificationViewModel>).ToList();
            return v;
        }
    }
}
