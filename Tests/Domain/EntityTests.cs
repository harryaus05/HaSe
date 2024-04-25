using HaSe.Data.Contoso;
using HaSe.Domain;
using HaSe.Helpers.Methods;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Domain {
    [TestClass] public class EntityTests : AbstractTests<Entity<CourseData>, object> {
        private class _Entity(CourseData? data) : Entity<CourseData>(data) { }

        private dynamic? _data;
        protected override Entity<CourseData>? CreateObject() {
            _data = GetRandom.Object<CourseData>();
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
