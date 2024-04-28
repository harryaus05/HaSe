using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Project {
    public sealed class PartViewModel : EntityViewModel {
        [DisplayName("Description")]
        [Required, MinLength(3, ErrorMessage = "Description needs to be at least 3 characters")]
        public string Name { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "Type needs to be at least 3 characters")]
        public string Type { get; set; }

    }
}
