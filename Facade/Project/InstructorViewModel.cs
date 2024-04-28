using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Project {
    public sealed class InstructorViewModel : EntityViewModel {
        [DisplayName("First Description")] 
        public string? FirstName { get; set; }

        [DisplayName("Last Description")] 
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Hire Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime HireDate { get; set; }
        [DisplayName("Full Description")] public string? FullName { get; set; }
    }
}
