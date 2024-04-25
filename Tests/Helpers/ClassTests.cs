namespace HaSe.Tests.Helpers;

public abstract class ClassTests<TClass, TBaseClass> : AbstractTests<TClass, TBaseClass> where TClass : class {
    [TestMethod] public override void IsAbstractTest() {
        Assert.IsFalse(typeof(TClass)?.IsAbstract);
    }

    [TestMethod] public void CanCreateTest() {
        Assert.IsInstanceOfType(obj, typeof(TClass));
    }
}