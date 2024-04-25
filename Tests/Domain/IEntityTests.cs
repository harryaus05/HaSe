using HaSe.Domain;

namespace HaSe.Tests.Domain {
    [TestClass] public class IEntityTests : InterfaceTests<IEntity> {
        [TestMethod] public void IdTest() => PropertyTest<int>();
    }
}
