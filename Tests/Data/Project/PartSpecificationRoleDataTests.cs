using HaSe.Data;
using HaSe.Data.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Project;

[TestClass]
public class PartSpecificationRoleDataTests : SealedNewTests<PartSpecificationRoleData, EntityData> {
    [TestMethod] public void PartyNameTest() => PropertyTest();
    [TestMethod] public void TypeTest() => PropertyTest();

}