using Math = HaSe.Helpers.Methods.Math;
using Rnd = HaSe.Helpers.Methods.GetRandom;

namespace HaSe.Tests.Helpers.Methods {
    [TestClass]
    public class MathTests : BaseTests {
        protected override Type? type => typeof(Math);

        [TestMethod, DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void AddTest(double x, double y) => Assert.AreEqual(x + y, Math.Add(x, y));

        [TestMethod, DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void SubtractTest(double x, double y) => Assert.AreEqual(x - y, Math.Subtract(x, y));

        [TestMethod, DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void DivideTest(double x, double y) => Assert.AreEqual(x / y, Math.Divide(x, y));

        [TestMethod, DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void MultiplyTest(double x, double y) => Assert.AreEqual(x * y, Math.Multiply(x, y));

        [TestMethod, DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void DivideByZeroTest(double x, double y) => Assert.AreEqual(x < 0 ? double.NegativeInfinity : double.PositiveInfinity, Math.Divide(x, 0.0));

        private static IEnumerable<object[]> TestData() {
            yield return [Rnd.Int32(), Rnd.Int32()];
            yield return [Rnd.Double(), Rnd.Double()];
            yield return [Rnd.Double(), 0];
            yield return [int.MaxValue, 1];
            yield return [int.MaxValue, -1];
            yield return [int.MinValue, 1];
            yield return [int.MinValue, -1];
        }
    }
}
