using HaSe.Data.Project;

namespace HaSe.Domain.Project {
    public sealed class Part(PartData? data) : Entity<PartData>(data) {
        public string Name => data.Name;
        public string Type => data.Type;
    }
}
