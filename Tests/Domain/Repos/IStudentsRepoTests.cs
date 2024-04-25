using HaSe.Domain.Common;
using HaSe.Domain.Contoso;
using HaSe.Domain.Repos;

namespace HaSe.Tests.Domain.Repos;

[TestClass]
public class IStudentsRepoTests : InterfaceTests<IStudentsRepo, IPagedRepo<Student>> {
}