using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationStatus(PartSpecificationStatusData? data) : PartSpecificationRelation<PartSpecificationStatusData>(data) {

        public async override Task LoadLazy() {
            await base.LoadLazy();
            PartSpecification ??= await GetFromRepo.Item<IPartSpecificationRepo, PartSpecification>(PartSpecificationId);
        }
        public DateTime FromDate => data.FromDate;
        public DateTime ThruDate => data.ThruDate;
        public string Type => data.Type;    
        public int PartSpecificationId => data.PartSpecificationId;
        public PartSpecification? PartSpecification { get; private set; }
    }
}
