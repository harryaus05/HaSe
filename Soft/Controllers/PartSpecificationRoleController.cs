using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Soft.Controllers {
    public class PartSpecificationRoleController(IPartSpecificationRoleRepo repo)
        : BaseController<PartSpecificationRole, PartSpecificationRoleViewModel>(repo) {
        protected override string selectItemTextField => nameof(PartSpecificationRoleViewModel.PartyName);

        protected override PartSpecificationRole ToModel(PartSpecificationRoleViewModel viewmodel) {
            return new PartSpecificationRole(
                PropertyCopier
                    .CopyPropertiesFrom<PartSpecificationRoleViewModel, PartSpecificationRoleData>(viewmodel));
        }
    }
}
