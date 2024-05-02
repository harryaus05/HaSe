namespace HaSe.Data.Project {
    public sealed class PartSpecificationData : EntityData {
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime DateDocumented { get; set; }
        public string? Comment { get; set; }
        public int? PartId { get; set; }    
    }
}
