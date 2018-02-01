namespace mUnit.Core.Core
{
    using System.Reflection;

    public class AssemblyLoader
    {
        private Assembly assembly;

        public AssemblyLoader(string assemblyPath)
        {
            this.AssemblyPath = assemblyPath;
        }

        public string AssemblyPath { get; private set; }

        public Assembly Assembly
        {
            get
            {
                if (this.assembly == null)
                {
                    this.assembly = Assembly.LoadFrom(this.AssemblyPath);
                }

                return this.assembly;
            }
        }
    }
}
