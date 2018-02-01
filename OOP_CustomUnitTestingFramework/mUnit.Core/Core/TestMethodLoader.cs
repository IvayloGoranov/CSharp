namespace mUnit.Core.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes;

    public class TestMethodLoader
    {
        public TestMethodLoader(Assembly assembly)
        {
            this.Assembly = assembly;
        }

        public Assembly Assembly { get; private set; }

        public Dictionary<Type, List<MethodInfo>> LoadTestMethods()
        {
            var allTypesInAssembly = this.Assembly.GetTypes();
            var typeData = new Dictionary<Type, List<MethodInfo>>();
            foreach (Type type in allTypesInAssembly)
            {
                var customAttributes = type.GetCustomAttributes();
                bool hasTestContainerAttribute = customAttributes
                    .Any(a => a is TestContainerAttribute);

                if (type.IsClass && hasTestContainerAttribute)
                {
                    GetTestMethods(typeData, type);
                }
            }

            return typeData;
        }

        private static void GetTestMethods(Dictionary<Type, List<MethodInfo>> typeData, Type type)
        {
            typeData[type] = new List<MethodInfo>();
            var allMethods = type.GetMethods();
            foreach (var method in allMethods)
            {
                bool hasTestAttribute = method
                    .GetCustomAttributes()
                    .Any(a => a is TestAttribute);
                if (hasTestAttribute)
                {
                    typeData[type].Add(method);
                }
            }
        }
    }
}
