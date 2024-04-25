using System.Text;

namespace HaSe.Helpers.Methods {
    public static class GetRandom {
        private static readonly Random _random = new();

        public static bool Bool() {
            return Int32() % 2 == 0;
        }

        public static char Char(char min = char.MinValue, char max = char.MaxValue) {
            return (char)UInt16(min, max);
        }

        public static string String(byte minLength = 5, byte maxLength = 10) {
            var builder = new StringBuilder();
            var size = UInt8(minLength, maxLength);
            for (var i = 0; i < size; i++) {
                builder.Append(Char('a', 'z'));
            }
            return builder.ToString();
        }

        public static DateTime DateTime(DateTime? min = null, DateTime? max = null) {
            var minValue = (min ?? System.DateTime.Today.AddYears(-10)).Ticks;
            var maxValue = (max ?? System.DateTime.Today.AddYears(10)).Ticks;
            var ticks = Int64(minValue, maxValue);
            return new DateTime(ticks);
        }

        public static decimal Decimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue) {
            int[] bits = [Int32(), Int32(), Int32(), 0];
            var d = new decimal(bits);
            if (d < min || d > max) {
                var range = max - min;
                var fractions = d / decimal.MaxValue;
                d = min + fractions * range;
            }
            return d;
        }

        public static double Double(double min = short.MinValue, double max = short.MaxValue) {
            if (min > max)
                (min, max) = (max, min);

            var d = _random.NextDouble();
            if (max > 0)
                return min + d * max - d * min;
            return min - d * min + d * max;
        }

        public static float Float(float min = short.MinValue, float max = short.MaxValue) {
            return (float)Double(min, max);
        }

        public static long Int64(long min = long.MinValue, long max = long.MaxValue) {
            return (long)Double(min, max);
        }

        public static int Int32(int min = int.MinValue, int max = int.MaxValue) {
            if (min == max)
                return min;
            return max < min ? _random.Next(max, min) : _random.Next(min, max);
        }

        public static short Int16(short min = short.MinValue, short max = short.MaxValue) {
            return (short)Int32(min, max);
        }

        public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue) {
            return (sbyte)Int32(min, max);
        }

        public static ulong UInt64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue) {
            return (ulong)Double(min, max);
        }

        public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue) {
            return (uint)Double(min, max);
        }

        public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue) {
            return (ushort)Int32(min, max);
        }

        public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue) {
            return (byte)Int32(min, max);
        }

        public static dynamic? Any(Type? t) {
            if (t == typeof(string)) return String();
            if (t == typeof(long) || t == typeof(long?)) return Int64();
            if (t == typeof(int) || t == typeof(int?)) return Int32();
            if (t == typeof(short) || t == typeof(short?)) return Int16();
            if (t == typeof(sbyte) || t == typeof(sbyte?)) return Int8();
            if (t == typeof(ulong) || t == typeof(ulong?)) return UInt64();
            if (t == typeof(uint) || t == typeof(uint?)) return UInt32();
            if (t == typeof(ushort) || t == typeof(ushort?)) return UInt16();
            if (t == typeof(byte) || t == typeof(byte?)) return UInt8();
            if (t == typeof(char) || t == typeof(char?)) return Char();
            if (t == typeof(double) || t == typeof(double?)) return Double();
            if (t == typeof(float) || t == typeof(float?)) return Float();
            if (t == typeof(DateTime) || t == typeof(DateTime?)) return DateTime();
            if (t == typeof(bool) || t == typeof(bool?)) return Bool();
            if (t == typeof(decimal) || t == typeof(decimal?)) return Decimal();
            else return null;
        }

        public static TObject Object<TObject>() where TObject : class, new() {
            var obj = new TObject();
            foreach (var property in obj.GetType().GetProperties()) {
                if (!property.CanWrite) continue;
                var value = Any(property.PropertyType);
                property.SetValue(obj, value, null);
            }
            return obj;
        }
    }
}
