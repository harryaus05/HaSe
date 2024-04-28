using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Project {
    public sealed class PartViewModel : EntityViewModel {
        [DisplayName("Name")]
        [Required, MinLength(3, ErrorMessage = "Name needs to be at least 3 characters")]
        public string Name { get; set; }

        [DisplayName("Type")]
        [Required, MinLength(3, ErrorMessage = "Type needs to be at least 3 characters")]
        public string Type { get; set; }

    }
}
