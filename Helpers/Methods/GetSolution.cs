using System.Reflection;

namespace HaSe.Helpers.Methods {
    public static class GetSolution {
        public static Assembly Assembly(string name) {
            return System.Reflection.Assembly.Load(name);
        }
        public static List<Type> Types(string assemblyName) {
            return Types(Assembly(assemblyName));
        }
        public static List<Type> Types(Assembly assembly) {
            return assembly.GetTypes().Where(x => !x.Name.StartsWith('<')).ToList();
        }
    }
}

