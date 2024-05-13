using HaSe.Data.Project;

namespace HaSe.Domain.Project {
    public sealed class Part(PartData? data) : Entity<PartData>(data) {
        public string Name => _data.Name;
        public string Type => _data.Type;        
    }
}
