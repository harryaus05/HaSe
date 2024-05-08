using HaSe.Data.Project;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationRole(PartSpecificationRoleData? data) : Entity<PartSpecificationRoleData>(data) {
        public string PartyName => _data.PartyName;
        public string Type => _data.Type;
    }
}
