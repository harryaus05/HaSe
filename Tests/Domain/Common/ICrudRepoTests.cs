using HaSe.Domain.Common;
using HaSe.Domain.Contoso;

namespace HaSe.Tests.Domain.Common
{
    [TestClass] public class ICrudRepoTests : InterfaceTests<ICrudRepo<Course>> {
        [TestMethod] public void GetAsyncListTest() => MethodTest<Task<IEnumerable<Course>>>("List");
        [TestMethod] public void GetAsyncTest() => MethodTest<Task<Course?>>(typeof(int));
        [TestMethod] public void FindAsyncTest() => MethodTest<Task<Course?>>(typeof(int));
        [TestMethod] public void UpdateAsyncTest() => MethodTest<Task<bool>>(typeof(Course));
        [TestMethod] public void AddAsyncTest() => MethodTest<Task<bool>>(typeof(Course));
        [TestMethod] public void DeleteAsyncTest() => MethodTest<Task<bool>>(typeof(int));

    
    }
}
