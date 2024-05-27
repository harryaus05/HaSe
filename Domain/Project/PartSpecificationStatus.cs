using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationStatus(PartSpecificationStatusData? data) : Entity<PartSpecificationStatusData>(data) {

        public override async Task LoadLazy() {
            await base.LoadLazy();
            Specification ??= await GetFromRepo.Item<IPartSpecificationRepo, PartSpecification>(PartSpecificationId);
            //Specification ??= await GetFromRepo.Items<IPartSpecificationRepo, PartSpecification>(nameof(PartSpecificationData.Id), Id);
        }
        public DateTime FromDate => data.FromDate;
        public DateTime ThruDate => data.ThruDate;
        public int PartSpecificationId => data.PartSpecificationId;
        public PartSpecification? Specification { get; private set; }
        public string Type => data.Type;
    }
}
