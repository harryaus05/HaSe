using HaSe.Data.Project;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Project
{
    [TestClass]
    public class PartSpecificationTests : DomainClassTests<PartSpecification, PartSpecificationData>
    {
        [TestMethod] public void DescriptionTest() => ValueTest();
        [TestMethod] public void TypeTest() => ValueTest();
        [TestMethod] public void DateDocumentedTest() => ValueTest();
        [TestMethod] public void CommentTest() => ValueTest();
        [TestMethod] public void PartIdTest() => ValueTest();
    }
}