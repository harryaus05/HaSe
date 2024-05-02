using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaSe.Facade.Project {
    public class PartSpecificationStatusViewModel : EntityViewModel {
        [DataType(DataType.Date)]
        [DisplayName("From Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Thru Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ThruDate { get; set; }
    }
}
