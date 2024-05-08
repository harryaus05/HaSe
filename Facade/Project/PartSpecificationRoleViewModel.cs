using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaSe.Facade.Project {
    public class PartSpecificationRoleViewModel : EntityViewModel {
        [DisplayName("Party Name")]
        [Required, MinLength(3, ErrorMessage = "Name needs to be at least 3 characters")]
        public string PartyName { get; set; }

        [DisplayName("Type")]
        [Required]
        public string Type { get; set; }
    }
}
