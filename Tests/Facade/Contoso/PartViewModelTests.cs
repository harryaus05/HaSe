using HaSe.Facade;
using HaSe.Facade.Contoso;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Contoso {
    [TestClass] public class PartViewModelTests : SealedNewTests<CourseViewModel, EntityViewModel> {
        [TestMethod] public void CreditsTest() => PropertyTest("Credits", true);
        [TestMethod] public void DepartmentIdTest() => PropertyTest("Department Id");
        [TestMethod] public void TitleTest() => PropertyTest("Name", true);
    }
}
