using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using HaSe.Helpers.Methods;

namespace HaSe.Tests.Helpers {
    public abstract class AbstractTests<TClass, TBaseClass> : BaseTests {
        protected TClass? obj;
        protected abstract TClass? CreateObject();
        protected override Type? type => typeof(TClass);
        protected virtual Type baseType => typeof(TBaseClass);

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = CreateObject();
        }

        [TestMethod] public void IsBaseClassTest() => Assert.AreEqual(typeof(TClass)?.BaseType?.Name, baseType.Name);
        [TestMethod] public virtual void IsAbstractTest() => Assert.IsTrue(typeof(TClass)?.IsAbstract);

        protected void PropertyTest(string? displayName = null, bool? isRequired = null) {
            var name = CallingMethod(nameof(PropertyTest));
            var property = type?.GetProperty(name);
            ValidateDisplayName(property, displayName);
            ValidateIsRequired(property, isRequired);
            var propertyType = property?.PropertyType;
            var value = GetRandom.Any(propertyType);
            Assert.IsNotNull(value, $"GetRandom.Any returns null for type <{propertyType?.Name}>");
            property?.SetValue(obj, value);
            Assert.AreEqual(value, property?.GetValue(obj));
        }

        private static void ValidateIsRequired(PropertyInfo? info, bool? isRequired) {
            if (isRequired is null) return;
            if (info is null) return;
            var actual = info.GetCustomAttribute<RequiredAttribute>();
            Assert.AreEqual(actual is not null, isRequired);
        }

        private static void ValidateDisplayName(PropertyInfo? info, string? displayName) {
            if (displayName is null) return;
            if (info is null) return;
            var actual = info.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
            Assert.AreEqual(displayName, actual);
        }
    }
}
