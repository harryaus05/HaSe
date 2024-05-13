namespace HaSe.Data.Project {
    public sealed class PartSpecificationStatusData : PartSpecificationRelationData {
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
        public string Type { get; set; }
        public int PartId { get; set; }
    }

    public abstract class PartSpecificationRelationData : EntityData {
        public int PartSpecificationId { get; set; }
    }
}
