using HaSe.Data;
using HaSe.Data.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Project;

[TestClass]
public class PartSpecificationStatusDataTests : SealedNewTests<PartSpecificationStatusData, EntityData> {
    [TestMethod] public void FromDateTest() => PropertyTest();
    [TestMethod] public void ThruDateTest() => PropertyTest();
    [TestMethod] public void TypeTest() => PropertyTest();

}