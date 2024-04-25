using HaSe.Domain.Common;
using HaSe.Domain.Contoso;

namespace HaSe.Tests.Domain.Common;

[TestClass] public class IOrderedRepoTests : InterfaceTests<IOrderedRepo<Course>, IFilteredRepo<Course>> {
    [TestMethod] public void SortOrderTest() => PropertyTest<string>();
}