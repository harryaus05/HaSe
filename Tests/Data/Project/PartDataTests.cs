using HaSe.Data;
using HaSe.Data.Project;
using HaSe.Tests.Helpers;


namespace HaSe.Tests.Data.Project {
    [TestClass]
    public class PartDataTests : SealedNewTests<PartData, EntityData> {
        [TestMethod] public void NameTest() => PropertyTest();
        [TestMethod] public void TypeTest() => PropertyTest();
    }
}
