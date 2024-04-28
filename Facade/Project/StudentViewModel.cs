using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Project {
    public sealed class StudentViewModel : EntityViewModel {
        [DisplayName("First Description")] 
        public string? FirstName { get; set; }

        [DisplayName("Last Description")] 
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Enrollment Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime EnrollmentDate { get; set; }
    }
}
