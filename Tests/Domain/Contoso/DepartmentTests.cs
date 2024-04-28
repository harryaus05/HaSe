using HaSe.Data.Contoso;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Contoso {
    [TestClass] public class DepartmentTests : DomainClassTests<Department, DepartmentData> {
        [TestMethod] public void BudgetTest() => ValueTest();
        [TestMethod] public void InstructorIdTest() => ValueTest();
        [TestMethod] public void NameTest() => ValueTest();
        [TestMethod] public void StartDateTest() => ValueTest();
    }
}