﻿using HaSe.Data.Project;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;

namespace HaSe.Tests.Helpers.Methods {
    [TestClass]
    public class PropertyCopierTests : BaseTests {
        protected override Type? type => typeof(PropertyCopier);

        [TestMethod] public void CopyPropertiesFromTest() {
            var testData = TestData();
            var method = typeof(PropertyCopier).GetMethod("CopyPropertiesFrom");

            foreach (var (sourceType, targetType) in testData) {
                var source = Activator.CreateInstance(sourceType);
                var genericMethod = method?.MakeGenericMethod(sourceType, targetType);
                var result = genericMethod?.Invoke(null, [source]);
                Assert.IsInstanceOfType(result, targetType);
                CompareProperties(source, result, Assert.AreEqual);
            }
        }

        private static Dictionary<Type, Type> TestData() {
            return new Dictionary<Type, Type>(){
                {typeof(PartData), typeof(PartViewModel)},
                {typeof(PartSpecificationData), typeof(PartSpecificationViewModel)},
            };
        }
    }
}
