using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public sealed class Part(PartData? data) : Entity<PartData>(data) {

        public override async Task LoadLazy() {
            await base.LoadLazy();
            PartSpecifications ??= await GetFromRepo.Items<IPartSpecificationRepo, PartSpecification>(nameof(PartSpecificationData.PartId), Id);
        }
        public string Name => data.Name;
        public string Type => data.Type;
        public List<PartSpecification>? PartSpecifications { get; private set; }
    }
}
