using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Contoso {
    [TestClass]
    public class InstructorViewModelTests : SealedNewTests<InstructorViewModel, EntityViewModel> {
        [TestMethod] public void FirstNameTest() => PropertyTest("First Name");
        [TestMethod] public void LastNameTest() => PropertyTest("Last Name");
        [TestMethod] public void HireDateTest() => PropertyTest("Hire Date");
        [TestMethod] public void FullNameTest() => PropertyTest("Full Name");
    }
}
