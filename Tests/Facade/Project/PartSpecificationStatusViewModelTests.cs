using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HaSe.Tests.Facade.Project
{
    [TestClass]
    public class PartSpecificationStatusViewModelTests : SealedNewTests<PartSpecificationStatusViewModel, EntityViewModel>
    {
        [TestMethod] public void FromDateTest() => PropertyTest("From Date", true);
        [TestMethod] public void ThruDateTest() => PropertyTest("Thru Date");
        [TestMethod] public void TypeTest() => PropertyTest("Type");
        [TestMethod] public void PartSpecificationIdTest() => PropertyTest("Part Specification");
    }
}
