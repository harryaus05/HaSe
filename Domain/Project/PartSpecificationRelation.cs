using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public abstract class PartSpecificationRelation<TData>(TData? d) : Entity<TData>(d) where TData : PartSpecificationRelationData, new() {
        public async override Task LoadLazy() {
            await base.LoadLazy();
            PartSpecification ??= await GetFromRepo.Item<IPartSpecificationRepo, PartSpecification>(PartSpecificationId);
        }
        public int PartSpecificationId => data.PartSpecificationId;
        public PartSpecification? PartSpecification { get; private set; }
    }
}
