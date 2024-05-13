using HaSe.Data.Project;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationRole(PartSpecificationRoleData? data) : Entity<PartSpecificationRoleData>(data) {
        public string PartyName => data.PartyName;
        public string Type => data.Type;
    }
}
