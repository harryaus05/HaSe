using HaSe.Domain.Project;
using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Project
{
    [TestClass]
    public class PartSpecificationViewModelTests : SealedNewTests<PartSpecificationViewModel, PartRelationViewModel>
    {
        [TestMethod] public void DescriptionTest() => PropertyTest("Description", true);
        [TestMethod] public void TypeTest() => PropertyTest("Type");
        [TestMethod] public void DateDocumentedTest() => PropertyTest("Date documented");
        [TestMethod] public void CommentTest() => PropertyTest("Comment");
        [TestMethod] public void PartIdTest() => PropertyTest("Part Id");
    }
}
