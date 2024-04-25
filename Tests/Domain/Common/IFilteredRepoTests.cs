using HaSe.Domain.Common;
using HaSe.Domain.Contoso;

namespace HaSe.Tests.Domain.Common;

[TestClass] public class IFilteredRepoTests : InterfaceTests<IFilteredRepo<Course>, ICrudRepo<Course>> {
    [TestMethod] public void SearchStringTest() => PropertyTest<string>();
}