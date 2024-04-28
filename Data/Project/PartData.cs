namespace HaSe.Data.Project
{
    public sealed class PartData : EntityData {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public int DepartmentId { get; set; }
    }
}
