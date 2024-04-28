using HaSe.Data.Contoso;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Contoso {
    [TestClass] public class StudentTests : DomainClassTests<Student, StudentData> {
        [TestMethod] public void FirstNameTest() => ValueTest();
        [TestMethod] public void LastNameTest() => ValueTest();
        [TestMethod] public void EnrollmentDateTest() => ValueTest();
    }
}