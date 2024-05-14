namespace HaSe.Data.Project {
    public sealed class PartSpecificationData : PartRelationData {
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime DateDocumented { get; set; }
        public string? Comment { get; set; }   
    }
    public abstract class PartRelationData : EntityData {
        public int PartId { get; set; }
    }
}
