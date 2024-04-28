using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Contoso {
    [TestClass] public class DepartmentViewModelTests : SealedNewTests<DepartmentViewModel, EntityViewModel> {
        [TestMethod] public void NameTest() => PropertyTest("Name");
        [TestMethod] public void BudgetTest() => PropertyTest("Budget");
        [TestMethod] public void StartDateTest() => PropertyTest("Start Date");
        [TestMethod] public void InstructorIdTest() => PropertyTest("Instructor Id");
    }
}
