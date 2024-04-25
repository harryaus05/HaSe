using HaSe.Tests.Helpers;

namespace HaSe.Tests.Domain;

public class InterfaceTests<TType> : BaseTests {
    protected override Type? type => typeof(TType);
    [TestMethod] public void IsInterface() => Assert.IsTrue(type?.IsInterface);

    protected void PropertyTest<TPropertyType>(bool isReadOnly = true) {
        var name = CallingMethod(nameof(PropertyTest));
        var property = type?.GetProperty(name);
        var t = property?.PropertyType;
        Assert.AreEqual(typeof(TPropertyType), t);
        Assert.AreEqual(property?.CanRead, true);
        Assert.AreEqual(property?.CanWrite, isReadOnly);
    }

    protected void MethodTest<TReturnType>(params Type[] expectedParameters) {
        var name = CallingMethod(nameof(MethodTest));
        MethodTest(typeof(TReturnType), name, expectedParameters);
    }

    protected void MethodTest<TReturnType>(string replaceInName, params Type[] expectedParameters) {
        var name = CallingMethod(nameof(MethodTest)).Replace(replaceInName, string.Empty);
        MethodTest(typeof(TReturnType), name, expectedParameters);
    }

    protected void MethodTest(Type returnType, string name, params Type[] expectedParameters) {
        var method = type?.GetMethod(name, expectedParameters);
        Assert.IsNotNull(method);
        Assert.AreEqual(returnType, method.ReturnType);
    }
}

public class InterfaceTests<TType, TBaseType> : InterfaceTests<TType> {
    [TestMethod] public void IsBaseTypeTest() {
        var baseInterfaces = type?.GetInterfaces();
        Assert.IsTrue(baseInterfaces?.Contains(typeof(TBaseType)));
    }
}