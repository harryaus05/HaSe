using HaSe.Data;
using HaSe.Data.Contoso;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Contoso {
    [TestClass]
    public class CourseDataTests : SealedNewTests<CourseData, EntityData> {
        [TestMethod] public void CreditsTest() => PropertyTest();
        [TestMethod] public void DepartmentIdTest() => PropertyTest();
        [TestMethod] public void TitleTest() => PropertyTest();
    }
}
