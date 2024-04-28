using HaSe.Data.Project;

namespace HaSe.Domain.Project {
    public sealed class PartSpecification(PartSpecificationData? data) : Entity<PartSpecificationData>(data) {
        public string Description => _data.Description;
        public string Type => _data.Type;
        public DateTime DateDocumented => _data.DateDocumented;
        public string? Comment => _data.Comment;
        public int? PartId => _data.PartId;
    }
}
