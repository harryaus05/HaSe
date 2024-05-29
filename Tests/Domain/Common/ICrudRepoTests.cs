using HaSe.Domain.Common;
using HaSe.Domain.Project;

namespace HaSe.Tests.Domain.Common
{
    [TestClass] public class ICrudRepoTests : InterfaceTests<ICrudRepo<Part>> {
        [TestMethod] public void GetAsyncListTest() => MethodTest<Task<IEnumerable<Part>>>("List");
        [TestMethod] public void GetAsyncTest() => MethodTest<Task<Part?>>(typeof(int));
        [TestMethod] public void UpdateAsyncTest() => MethodTest<Task<bool>>(typeof(Part));
        [TestMethod] public void AddAsyncTest() => MethodTest<Task<bool>>(typeof(Part));
        [TestMethod] public void DeleteAsyncTest() => MethodTest<Task<bool>>(typeof(int));

    }
}
