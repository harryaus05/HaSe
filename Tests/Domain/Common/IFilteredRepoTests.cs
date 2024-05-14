using HaSe.Domain.Common;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Common;

[TestClass] public class IFilteredRepoTests : InterfaceTests<IFilteredRepo<Part>, ICrudRepo<Part>> {
    [TestMethod] public void SearchStringTest() => PropertyTest<string>();
    [TestMethod] public void FixedFilterTest() => PropertyTest<string>();
}