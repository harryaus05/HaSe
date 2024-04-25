using HaSe.Data.Contoso;
using HaSe.Domain.Contoso;

namespace HaSe.Tests.Domain.Contoso {
    [TestClass] public class CourseTests : DomainClassTests<Course, CourseData> {
        [TestMethod] public void CreditsTest() => ValueTest();
        [TestMethod] public void DepartmentIdTest() => ValueTest();
        [TestMethod] public void TitleTest() => ValueTest();
    }
}
