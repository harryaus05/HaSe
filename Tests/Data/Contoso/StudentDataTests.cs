using HaSe.Data;
using HaSe.Data.Contoso;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Contoso;

[TestClass]
public class StudentDataTests : SealedNewTests<StudentData, EntityData> {
    [TestMethod] public void FirstNameTest() => PropertyTest();
    [TestMethod] public void LastNameTest() => PropertyTest();
    [TestMethod] public void EnrollmentDateTest() => PropertyTest();
}