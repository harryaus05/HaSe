using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Tests.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HaSe.Tests.Facade.Project
{
    [TestClass]
    public class PartSpecificationRoleViewModelTests : SealedNewTests<PartSpecificationRoleViewModel, EntityViewModel>
    {
        [TestMethod] public void PartyNameTest() => PropertyTest("Party Name", true);
        [TestMethod] public void TypeTest() => PropertyTest("Type", true);
       
    }
}
