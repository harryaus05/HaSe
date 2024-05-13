using HaSe.Data.Project;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Project {
    [TestClass]
    public class PartSpecificationStatusTests : DomainClassTests<PartSpecificationStatus, PartSpecificationStatusData> {
        [TestMethod] public void FromDateTest() => ValueTest();
        [TestMethod] public void ThruDateTest() => ValueTest();
        [TestMethod] public void TypeTest() => ValueTest();
    }
}
