using HaSe.Data.Project;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationStatus(PartSpecificationStatusData? data) : Entity<PartSpecificationStatusData>(data) {
        public DateTime FromDate => _data.FromDate;
        public DateTime ThruDate => _data.ThruDate;
        public string Type => _data.Type;
    }
}
