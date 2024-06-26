﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HaSe.Facade.Project {
    public sealed class PartSpecificationRoleViewModel : EntityViewModel {
        [DisplayName("Party Name")]
        [Required, MinLength(3, ErrorMessage = "Name needs to be at least 3 characters")]
        public string PartyName { get; set; }

        [DisplayName("Type")]
        [Required]
        public string Type { get; set; }
        [DisplayName("Part Specification")] public int PartSpecificationId { get; set; }
    }
}
