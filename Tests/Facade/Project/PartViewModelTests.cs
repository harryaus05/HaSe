using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Facade.Project
{
    [TestClass]
    public class PartViewModelTests : SealedNewTests<PartViewModel, EntityViewModel>
    {
        [TestMethod] public void NameTest() => PropertyTest("Name", true);
        [TestMethod] public void TypeTest() => PropertyTest("Type", true);

    }
}
