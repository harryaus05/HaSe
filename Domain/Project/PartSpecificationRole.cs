using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationRole(PartSpecificationRoleData? data) : Entity<PartSpecificationRoleData>(data) {
        public override async Task LoadLazy() {
            await base.LoadLazy();
            Specification ??= await GetFromRepo.Item<IPartSpecificationRepo, PartSpecification>(PartSpecificationId);
        }
        public string PartyName => data.PartyName;
        public string Type => data.Type;
        public PartSpecification? Specification { get; private set; }
        public int PartSpecificationId => data.PartSpecificationId;
    }
}
