using HaSe.Facade;
using HaSe.Facade.Contoso;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Contoso {
    [TestClass]
    public class StudentViewModelTests : SealedNewTests<StudentViewModel, EntityViewModel> {
        [TestMethod] public void FirstNameTest() => PropertyTest("First Name");
        [TestMethod] public void LastNameTest() => PropertyTest("Last Name");
        [TestMethod] public void EnrollmentDateTest() => PropertyTest("Enrollment Date");
    }
}
