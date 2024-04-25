namespace HaSe.Tests.Helpers;

public abstract class SealedTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : class {
    [TestMethod] public void IsSealedTest() {
        Assert.IsTrue(typeof(TClass)?.IsSealed);
    }
}