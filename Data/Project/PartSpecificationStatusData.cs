using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaSe.Data.Project {
    public sealed class PartSpecificationStatusData : EntityData {
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
    }
}
