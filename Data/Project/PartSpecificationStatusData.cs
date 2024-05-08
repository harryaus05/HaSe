namespace HaSe.Data.Project {
    public sealed class PartSpecificationStatusData : EntityData {
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
        public string Type { get; set; }
    }
}
