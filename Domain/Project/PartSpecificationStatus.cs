using HaSe.Data.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationStatus(PartSpecificationStatusData? data) : Entity<PartSpecificationStatusData>(data) {
        public DateTime FromDate => _data.FromDate;
        public DateTime ThruDate => _data.ThruDate;
    }
}
