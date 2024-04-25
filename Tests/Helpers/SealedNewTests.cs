namespace HaSe.Tests.Helpers;

public abstract class SealedNewTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : class, new() {
    protected override TClass? CreateObject() => new();
    [TestMethod] public void IsSealedTest() {
        Assert.IsTrue(typeof(TClass)?.IsSealed);
    }
}