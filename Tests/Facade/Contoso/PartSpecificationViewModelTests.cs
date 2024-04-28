using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Contoso {
    [TestClass] public class PartSpecificationViewModelTests : SealedNewTests<PartSpecificationViewModel, EntityViewModel> {
        [TestMethod] public void NameTest() => PropertyTest("Description");
        [TestMethod] public void BudgetTest() => PropertyTest("Type");
        [TestMethod] public void StartDateTest() => PropertyTest("Start Date");
        [TestMethod] public void InstructorIdTest() => PropertyTest("Instructor Id");
    }
}
