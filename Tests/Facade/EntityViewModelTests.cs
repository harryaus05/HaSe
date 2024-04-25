using HaSe.Facade;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade {
    [TestClass] public class EntityViewModelTests : AbstractTests<EntityViewModel, object> {
        private class TestClass : EntityViewModel { }
        protected override EntityViewModel? CreateObject() => new TestClass();
        [TestMethod] public void IdTest() => PropertyTest();
    }
}
