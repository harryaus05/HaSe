using HaSe.Data;
using HaSe.Data.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Contoso;

[TestClass]
public class InstructorDataTests : SealedNewTests<InstructorData, EntityData> {
    [TestMethod] public void FirstNameTest() => PropertyTest();
    [TestMethod] public void LastNameTest() => PropertyTest();
    [TestMethod] public void HireDateTest() => PropertyTest();
}