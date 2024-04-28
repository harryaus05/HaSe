using HaSe.Data.Contoso;
using HaSe.Data.Project;
using HaSe.Domain;
using HaSe.Helpers.Methods;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Domain {
    [TestClass] public class EntityTests : AbstractTests<Entity<PartData>, object> {
        private class _Entity(PartData? data) : Entity<PartData>(data) { }

        private dynamic? _data;
        protected override Entity<PartData>? CreateObject() {
            _data = GetRandom.Object<PartData>();
            return new _Entity(_data);
        }

        [TestMethod] public void DataTest() {
            AreEqualProperties(_data, obj?.Data);
        }

        [TestMethod] public void IdTest() {
            Assert.AreEqual(_data?.Id, obj?.Id);
        }
    }
}
