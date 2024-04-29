using HaSe.Data;
using HaSe.Data.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Contoso;

[TestClass]
public class PartSpecificationDataTests : SealedNewTests<PartSpecificationData, EntityData> {
    [TestMethod] public void DescriptionTest() => PropertyTest();
    [TestMethod] public void TypeTest() => PropertyTest();
    [TestMethod] public void DateDocumentedTest() => PropertyTest();
    [TestMethod] public void CommentTest() => PropertyTest();
    [TestMethod] public void PartIdTest() => PropertyTest();
}