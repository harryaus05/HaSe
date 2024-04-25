using HaSe.Helpers;

namespace HaSe.Tests.Helpers {
    [TestClass] public class ConstantsTests : BaseTests {
        protected override Type? type => typeof(Constants);
        [TestMethod] public void SelectTest() => Assert.AreEqual("Select", Constants.Select);
    }
}
