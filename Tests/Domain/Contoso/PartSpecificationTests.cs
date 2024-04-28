using HaSe.Data.Project;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Contoso {
    [TestClass] public class PartSpecificationTests : DomainClassTests<PartSpecification, PartSpecificationData> {
        [TestMethod] public void BudgetTest() => ValueTest();
        [TestMethod] public void InstructorIdTest() => ValueTest();
        [TestMethod] public void NameTest() => ValueTest();
        [TestMethod] public void StartDateTest() => ValueTest();
    }
}