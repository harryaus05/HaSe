using HaSe.Domain.Common;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Common;

[TestClass] public class IOrderedRepoTests : InterfaceTests<IOrderedRepo<Part>, IFilteredRepo<Part>> {
    [TestMethod] public void SortOrderTest() => PropertyTest<string>();
}