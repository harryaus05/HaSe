using HaSe.Data.Project;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Project
{
    [TestClass]
    public class PartSpecificationRoleTests : DomainClassTests<PartSpecificationRole, PartSpecificationRoleData>
    {
        [TestMethod] public void PartyNameTest() => ValueTest();
        [TestMethod] public void TypeTest() => ValueTest();
    }
}
