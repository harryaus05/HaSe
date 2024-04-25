using HaSe.Data.Contoso;
using HaSe.Domain.Contoso;

namespace HaSe.Tests.Domain.Contoso {
    [TestClass]
    public class InstructorTests : DomainClassTests<Instructor, InstructorData> {
        [TestMethod] public void HireDateTest() => ValueTest();
        [TestMethod] public void FirstNameTest() => ValueTest();
        [TestMethod] public void LastNameTest() => ValueTest();
        [TestMethod] public void ToStringTest() => Assert.AreEqual($"{obj?.FirstName} {obj?.LastName}", obj?.ToString());
    }
}