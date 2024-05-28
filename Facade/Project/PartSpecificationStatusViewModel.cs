using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace HaSe.Facade.Project {
    [Description("Part Specification Status")] public sealed class PartSpecificationStatusViewModel : EntityViewModel {
        [DataType(DataType.Date)] [Required, DisplayName("From Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] public DateTime FromDate { get; set; }
        [DataType(DataType.Date)] [DisplayName("Thru Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] public DateTime ThruDate { get; set; }
        [DisplayName("Type")] [Required] public string Type { get; set; }
        [DisplayName("Part Specification")] public int PartSpecificationId { get; set; }
        [DisplayName("Part Specifications")] public List<PartSpecificationViewModel>? PartSpecification { get; set; }
    }
    //public abstract class PartSpecificationStatusRelationViewModel : EntityViewModel {
    //    [DisplayName("PartSpecification")]
    //    public int PartSpecificationId { get; set; }
    //}
}
