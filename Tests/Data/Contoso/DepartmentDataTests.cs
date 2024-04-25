using HaSe.Data;
using HaSe.Data.Contoso;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Contoso;

[TestClass]
public class DepartmentDataTests : SealedNewTests<DepartmentData, EntityData> {
    [TestMethod] public void NameTest() => PropertyTest();
    [TestMethod] public void BudgetTest() => PropertyTest();
    [TestMethod] public void StartDateTest() => PropertyTest();
    [TestMethod] public void InstructorIdTest() => PropertyTest();
}