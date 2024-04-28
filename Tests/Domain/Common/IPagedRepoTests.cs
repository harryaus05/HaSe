using HaSe.Domain.Common;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Common {
    [TestClass]
    public class IPagedRepoTests : InterfaceTests<IPagedRepo<Part>, IOrderedRepo<Part>> {
        [TestMethod] public void PageNumberTest() => PropertyTest<int?>();
        [TestMethod] public void PageTest() => PropertyTest<int>(false);
        [TestMethod] public void PageSizeTest() => PropertyTest<int>();
        [TestMethod] public void TotalPagesTest() => PropertyTest<int>(false);
        [TestMethod] public void TotalItemsTest() => PropertyTest<int>(false);
        [TestMethod] public void HasNextPageTest() => PropertyTest<bool>(false);
        [TestMethod] public void HasPreviousPageTest() => PropertyTest<bool>(false);
    }
}
