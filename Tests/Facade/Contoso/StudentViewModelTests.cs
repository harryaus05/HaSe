using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Contoso {
    [TestClass]
    public class StudentViewModelTests : SealedNewTests<StudentViewModel, EntityViewModel> {
        [TestMethod] public void FirstNameTest() => PropertyTest("First Description");
        [TestMethod] public void LastNameTest() => PropertyTest("Last Description");
        [TestMethod] public void EnrollmentDateTest() => PropertyTest("Enrollment Date");
    }
}
