using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Project {
    public sealed class PartSpecificationViewModel : EntityViewModel {
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

        [DisplayName("Part Id")]
        public int? PartId { get; set; }
    }
}
