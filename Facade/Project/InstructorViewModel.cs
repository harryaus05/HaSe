using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Project {
    public sealed class InstructorViewModel : EntityViewModel {
        [DisplayName("First Name")] 
        public string? FirstName { get; set; }

        [DisplayName("Last Name")] 
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Hire Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime HireDate { get; set; }
        [DisplayName("Full Name")] public string? FullName { get; set; }
    }
}
