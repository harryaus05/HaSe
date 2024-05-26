using HaSe.Data;
using HaSe.Data.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Project;

[TestClass]
public class PartSpecificationDataTests : SealedNewTests<PartSpecificationData, PartRelationData> {
    [TestMethod] public void DescriptionTest() => PropertyTest();
    [TestMethod] public void TypeTest() => PropertyTest();
    [TestMethod] public void DateDocumentedTest() => PropertyTest();
    [TestMethod] public void CommentTest() => PropertyTest();
    [TestMethod] public void PartIdTest() => PropertyTest();
}