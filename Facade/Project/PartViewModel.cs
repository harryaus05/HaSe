﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Project {
    public sealed class PartViewModel : EntityViewModel {
        [DisplayName("Name")]
        [Required, MinLength(3, ErrorMessage = "Name needs to be at least 3 characters")]
        public string Name { get; set; }

        //[DisplayName("Credits")]
        //[Required, Range(0, 12, ErrorMessage = "Credits must be between 0 and 12.")]
        //public int Credits { get; set; }

        [DisplayName("Department Id")] 
        public int? DepartmentId { get; set; }
    }
}
