using HaSe.Helpers.Methods;
using Math = HaSe.Helpers.Methods.Math;

namespace HaSe.Tests.Helpers.Methods {
    [TestClass]
    public class GetClassTests : BaseTests{
        protected override Type? type => typeof(GetClass);

        [TestMethod] public void MembersTest() {
            var memberNames = GetClass.Members(typeof(Math)).Select(member => member.Name);
            Assert.AreEqual(4, memberNames.Count());
            Assert.IsTrue(memberNames.Contains(nameof(Math.Add)));
            Assert.IsTrue(memberNames.Contains(nameof(Math.Subtract)));
            Assert.IsTrue(memberNames.Contains(nameof(Math.Multiply)));
            Assert.IsTrue(memberNames.Contains(nameof(Math.Divide)));
        }

        [TestMethod] public void MemberNamesTest() {
            var memberNames = GetClass.MemberNames(typeof(Math));
            Assert.AreEqual(4, memberNames.Count);
            Assert.IsTrue(memberNames.Contains(nameof(Math.Add)));
            Assert.IsTrue(memberNames.Contains(nameof(Math.Subtract)));
            Assert.IsTrue(memberNames.Contains(nameof(Math.Multiply)));
            Assert.IsTrue(memberNames.Contains(nameof(Math.Divide)));
        }
        [TestMethod] public void AssemblyTest() {
            var t = typeof(Math);
            var assembly = GetClass.Assembly(t);
            Assert.AreSame(assembly, t.Assembly);
        }
    }
}
