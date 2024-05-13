using HaSe.Facade.Project;
using HaSe.Helpers.Methods;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace HaSe.Tests.Helpers.Methods {
    [TestClass] public class GetRandomTests : BaseTests {
        protected override Type? type => typeof(GetRandom);

        [TestMethod, DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void AnyTest(Type? t) {
            var x = GetRandom.Any(t);
            var y = GetRandom.Any(t);
            while (x?.CompareTo(y) == 0) y = GetRandom.Any(t);
            Assert.AreNotEqual(x, y);
        }

        [TestMethod] public void BoolTest() => TestRandom(GetRandom.Bool);
        [TestMethod] public void CharTest() => TestRandom(() => GetRandom.Char(), GetRandom.Char);
        [TestMethod] public void DoubleTest() => TestRandom(() => GetRandom.Double(), GetRandom.Double);
        [TestMethod] public void DecimalTest() => TestRandom(() => GetRandom.Decimal(), GetRandom.Decimal);
        [TestMethod] public void DateTimeTest() => TestRandom(() => GetRandom.DateTime(), (x, y) => GetRandom.DateTime(x, y));
        [TestMethod] public void FloatTest() => TestRandom(() => GetRandom.Float(), GetRandom.Float);
        [TestMethod] public void Int64Test() => TestRandom(() => GetRandom.Int64(), GetRandom.Int64);
        [TestMethod] public void Int32Test() => TestRandom(() => GetRandom.Int32(), GetRandom.Int32);
        [TestMethod] public void Int16Test() => TestRandom(() => GetRandom.Int16(), GetRandom.Int16);
        [TestMethod] public void Int8Test() => TestRandom(() => GetRandom.Int8(), GetRandom.Int8);
        [TestMethod] public void StringTest() => Assert.AreNotEqual(GetRandom.String(), GetRandom.String());
        [TestMethod] public void UInt64Test() => TestRandom(() => GetRandom.UInt64(), GetRandom.UInt64);
        [TestMethod] public void UInt32Test() => TestRandom(() => GetRandom.UInt32(), GetRandom.UInt32);
        [TestMethod] public void UInt16Test() => TestRandom(() => GetRandom.UInt16(), GetRandom.UInt16);
        [TestMethod] public void UInt8Test() => TestRandom(() => GetRandom.UInt8(), GetRandom.UInt8);



        private static void TestRandom<T>(Func<T> f1, Func<T, T, T>? f2 = null) where T : IComparable<T> {
            TestRandom(f1, out T min, out T max);
            if(f2 is null) return;
            TestRandom(() => f2(min, max), out T x, out T y);
            if(min.CompareTo(max) < 0) IsBetween(x, min, max);
            else IsBetween(x, max, min);
        }

        private static void TestRandom<T>(Func<T> f, out T x, out T y) where T : IComparable<T> {
            x = f();
            y = f();
            while(x.CompareTo(y) == 0) y = f();
            Assert.AreNotEqual(x, y);
        }

        private static void testRnd<T>(Func<T> f) where T : IComparable<T> {
            T x = f();
            T y = f();
            while(x.CompareTo(y) == 0) y = f();
            Assert.AreNotEqual(x, y);
        }

        private static void IsBetween<T>(T x, T min, T max) where T : IComparable<T> {
            Assert.IsTrue(x.CompareTo(max) <= 0);
            Assert.IsTrue(x.CompareTo(min) >= 0);
        }
        private static IEnumerable<Type[]> TestData() {
            yield return [typeof(string)];
            yield return [typeof(long)];
            yield return [typeof(long?)];
            yield return [typeof(int)];
            yield return [typeof(int?)];
            yield return [typeof(short?)];
            yield return [typeof(short)];
            yield return [typeof(sbyte)];
            yield return [typeof(sbyte?)];
            yield return [typeof(ulong)];
            yield return [typeof(ulong?)];
            yield return [typeof(uint)];
            yield return [typeof(uint?)];
            yield return [typeof(ushort)];
            yield return [typeof(ushort?)];
            yield return [typeof(byte)];
            yield return [typeof(byte?)];
            yield return [typeof(char)];
            yield return [typeof(char?)];
            yield return [typeof(double)];
            yield return [typeof(double?)];
            yield return [typeof(float)];
            yield return [typeof(float?)];
            yield return [typeof(DateTime)];
            yield return [typeof(DateTime?)];
            yield return [typeof(bool)];
            yield return [typeof(bool?)];
            yield return [typeof(decimal)];
            yield return [typeof(decimal?)];
        }
    }
}
