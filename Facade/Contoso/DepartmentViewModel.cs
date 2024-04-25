using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Contoso {
    public sealed class DepartmentViewModel : EntityViewModel {
        [DisplayName("Name")]
        [Required, MinLength(2, ErrorMessage = "Name must have at least 2 characters."),
         RegularExpression(@"^[A-Za-z0-9ÜÕÖÄüõöä\s]+$", ErrorMessage = "Name can only contain latin/estonian letters, numbers and whitespaces.")]
        public string? Name { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Budget")] 
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("Instructor Id")]
        public int? InstructorId { get; set; }
    }
}
