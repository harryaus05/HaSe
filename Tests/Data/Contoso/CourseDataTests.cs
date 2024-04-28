using HaSe.Data;
using HaSe.Data.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Contoso {
    [TestClass]
    public class CourseDataTests : SealedNewTests<PartData, EntityData> {
        [TestMethod] public void CreditsTest() => PropertyTest();
        [TestMethod] public void DepartmentIdTest() => PropertyTest();
        [TestMethod] public void TitleTest() => PropertyTest();
    }
}
