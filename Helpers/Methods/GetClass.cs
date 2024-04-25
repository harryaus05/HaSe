using System.Reflection;

namespace HaSe.Helpers.Methods {
    public static class GetClass {
        private const BindingFlags _flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

        public static List<MemberInfo> Members(Type type) {
            return type.GetMembers(_flags).Where(x => IsNeeded(x.Name)).ToList();
        }

        private static bool IsNeeded(string name) {
            if (name.StartsWith("get_"))
                return false;
            if (name.StartsWith("set_"))
                return false;
            if (name.StartsWith("value__"))
                return false;
            if (name.StartsWith(".ctor"))
                return false;
            return true;
        }

        public static List<string> MemberNames(Type type) {
            return Members(type).Select(member => member.Name).ToList();
        }

        public static Assembly Assembly(Type type) {
            return type.Assembly;
        }
    }
}
