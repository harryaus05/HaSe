using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Contoso {
    [TestClass] public class PartViewModelTests : SealedNewTests<PartViewModel, EntityViewModel> {
        [TestMethod] public void CreditsTest() => PropertyTest("Credits", true);
        [TestMethod] public void DepartmentIdTest() => PropertyTest("PartSpecification Id");
        [TestMethod] public void TitleTest() => PropertyTest("Description", true);
    }
}
