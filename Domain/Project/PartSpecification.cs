using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public sealed class PartSpecification(PartSpecificationData? data) : Entity<PartSpecificationData>(data) {
        public override async Task LoadLazy() {
            await base.LoadLazy();
            SpecificationStatus ??= await GetFromRepo.Items<IPartSpecificationStatusRepo, PartSpecificationStatus>(nameof(PartSpecificationStatusData.PartSpecificationId), Id);
            Part ??= await GetFromRepo.Item<IPartsRepo, Part>(PartId);
            Parts ??= await GetFromRepo.Items<IPartsRepo, Part>(nameof(PartData.Name), Id);
        }
        public string Description => data.Description;
        public string Type => data.Type;
        public List<PartSpecificationStatus>? SpecificationStatus { get; private set; }
        public DateTime DateDocumented => data.DateDocumented;
        public string? Comment => data.Comment;
        public int PartId => data.PartId;
        public Part? Part { get; private set; }
        public List<Part>? Parts { get; private set; }
    }
}
