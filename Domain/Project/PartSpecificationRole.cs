using HaSe.Data.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationRole(PartSpecificationRoleData? data) : Entity<PartSpecificationRoleData>(data) {
        public string PartyName => _data.PartyName;
        public string Type => _data.Type;
    }
}
