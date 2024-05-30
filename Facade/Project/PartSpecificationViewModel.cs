using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Project {
    public sealed class PartSpecificationViewModel : PartRelationViewModel {
        [DisplayName("Description")]
        [Required, MinLength(2, ErrorMessage = "Description must have at least 2 characters."),
         RegularExpression(@"^[A-Za-z0-9ÜÕÖÄüõöä\s]+$", ErrorMessage = "Description can only contain latin/estonian letters, numbers and whitespaces.")]
        public string Description { get; set; }

        [DisplayName("Type")] 
        public string Type { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date documented"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateDocumented { get; set; }

        [DisplayName("Comment")]
        public string? Comment { get; set; }

        [DisplayName("Part Specification Status")] public List<PartSpecificationStatusViewModel>? SpecificationStatus { get; set; }
        [DisplayName("Part Specification Status")] public List<PartSpecificationRoleViewModel>? SpecificationRole { get; set; }
    }
    public abstract class PartRelationViewModel : EntityViewModel {
        [DisplayName("Part Id")][Required] public int PartId { get; set; }
    }
}
