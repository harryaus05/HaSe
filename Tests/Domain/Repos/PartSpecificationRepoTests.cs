using HaSe.Domain.Common;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;

namespace HaSe.Tests.Domain.Repos {
    [TestClass] public class PartSpecificationRepoTests : InterfaceTests<IPartSpecificationRepo, IPagedRepo<PartSpecification>> {
    }
}