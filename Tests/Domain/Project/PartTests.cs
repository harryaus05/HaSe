using HaSe.Data.Project;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Project
{
    [TestClass]
    public class PartTests : DomainClassTests<Part, PartData>
    {
        [TestMethod] public void NameTest() => ValueTest();
        [TestMethod] public void TypeTest() => ValueTest();
    }
}
