using HaSe.Domain.Common;
using HaSe.Domain.Contoso;
using HaSe.Domain.Repos;

namespace HaSe.Tests.Domain.Repos {
    [TestClass] public class ICoursesRepoTests : InterfaceTests<ICoursesRepo, IPagedRepo<Course>> {
    }
}
