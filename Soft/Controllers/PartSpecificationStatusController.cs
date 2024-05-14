using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class PartSpecificationStatusController(IPartSpecificationStatusRepo repo) : BaseController<PartSpecificationStatus, PartSpecificationStatusViewModel>(repo) {

        protected override PartSpecificationStatus ToModel(PartSpecificationStatusViewModel v) => new(Copy.Members<PartSpecificationStatusViewModel, PartSpecificationStatusData>(v));
        protected override async Task<PartSpecificationStatusViewModel> ToViewAsync(PartSpecificationStatus m) {
            if(loadLazy) await m.LoadLazy();
            var v = await base.ToViewAsync(m);
            return v;
        }
    }
}
