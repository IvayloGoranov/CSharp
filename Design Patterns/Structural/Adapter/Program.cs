namespace Adapter
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            ICompound water = new RichCompound("Water");
            ProcessCompound(water);

            ICompound benzene = new RichCompound("Benzene");
            ProcessCompound(benzene);

            ICompound ethanol = new RichCompound("Ethanol");
            ProcessCompound(ethanol);
        }

        internal static void ProcessCompound(ICompound compound)
        {
            // Process something
            compound.Display();
            // More processing...
        }
    }
}
