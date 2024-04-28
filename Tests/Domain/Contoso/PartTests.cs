using HaSe.Data.Contoso;
using HaSe.Data.Project;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Contoso {
    [TestClass] public class PartTests : DomainClassTests<Part, PartData> {
        [TestMethod] public void CreditsTest() => ValueTest();
        [TestMethod] public void DepartmentIdTest() => ValueTest();
        [TestMethod] public void TitleTest() => ValueTest();
    }
}
