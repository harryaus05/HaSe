using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HaSe.Facade.Contoso {
    public sealed class CourseViewModel : EntityViewModel {
        [DisplayName("Title")]
        [Required, MinLength(3, ErrorMessage = "Title needs to be at least 3 characters")]
        public string? Title { get; set; }

        [DisplayName("Credits")]
        [Required, Range(0, 12, ErrorMessage = "Credits must be between 0 and 12.")]
        public int Credits { get; set; }

        [DisplayName("Department Id")] 
        public int DepartmentId { get; set; }
    }
}
