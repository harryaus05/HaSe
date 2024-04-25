using System.Diagnostics;
using HaSe.Helpers.Methods;

namespace HaSe.Tests.Helpers {
    public abstract class BaseTests {
        protected abstract Type? type { get; }
        [TestInitialize] public virtual void TestInitialize() { }

        [TestMethod] public void IsTested() {
            var tests = GetClass.MemberNames(GetType());
            var members = (type is null) ? [] : GetClass.MemberNames(type);
            foreach (var m in members) {
                if (tests.Contains(m + "Test")) continue;
                Assert.Inconclusive($"Member <{m}> is not tested");
            }
        }

        protected static string CallingMethod(string methodName) {
            var stackTrace = new StackTrace();
            var index = CallingMethodIndex(stackTrace, methodName);
            return CallingMethodName(stackTrace, index);
        }

        protected static int CallingMethodIndex(StackTrace stackTrace, string methodName) {
            var index = -1;
            for (var i = 0; i < stackTrace.FrameCount; i++) {
                var name = stackTrace.GetFrame(i)?.GetMethod()?.Name;
                if (name != methodName) continue;
                index = i;
                break;
            }
            return index;
        }

        protected static string CallingMethodName(StackTrace stackTrace, int index) {
            var result = string.Empty;
            for (index += 1; index < stackTrace.FrameCount; index++) {
                result = stackTrace.GetFrame(index)?.GetMethod()?.Name ?? string.Empty;
                if (result is "MoveNext" or "Start")
                    continue;
                result = result.Replace("Test", String.Empty);
                break;
            }
            return result;
        }

        protected static void AreEqualProperties(object x, object y) =>
            CompareProperties(x, y, Assert.AreEqual);

        protected static void AreNotEqualProperties(object x, object y, params string[] excludedProperties) => 
            CompareProperties(x, y, Assert.AreNotEqual, excludedProperties);

        protected static void CompareProperties(object? x, object? y, Action<object?, object?> comparisonTest, params string[] excludedProperties) {
            if (x is null) Assert.Inconclusive("First object is null");
            if (y is null) Assert.Inconclusive("Second object is null");
            foreach (var firstObjectProperty in x.GetType().GetProperties()) {
                if (excludedProperties.Contains(firstObjectProperty.Name)) continue;
                var firstObjectValue = firstObjectProperty.GetValue(x);
                var secondObjectProperty = y.GetType().GetProperty(firstObjectProperty.Name);
                if (secondObjectProperty is null) continue;
                var secondObjectValue = secondObjectProperty.GetValue(y);
                comparisonTest(firstObjectValue, secondObjectValue);
            }
        }
    }
}
