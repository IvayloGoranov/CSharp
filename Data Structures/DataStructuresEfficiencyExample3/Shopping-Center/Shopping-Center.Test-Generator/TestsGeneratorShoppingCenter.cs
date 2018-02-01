using System;
using System.IO;
using ShoppingCenter;

namespace ShoppingCenter.TestGenerator
{
    public class TestsGeneratorShoppingCenter
    {
        const string inputFileName = "input-large.in";
        const string outputFileName = "output-large.out";
        static Random rand = new Random();

        static string[][] commands =
	{
		new string[]
		{
			"AddProduct thinkpad l61;11.3;Lenovo", "AddProduct l51;12.3;Lenovo", "AddProduct m61;15.3;MSI",
			"AddProduct t52;16.31;Toshiba", "AddProduct t61;12.3;Toshiba", "AddProduct t13;2.3;Toshiba",
			"AddProduct t92;125.3;Toshiba", "AddProduct t37;312.3;Toshiba", "AddProduct t03;712.3;Toshiba", 
			"AddProduct d123;24.3;Dell", "AddProduct d234;98.3;Dell", "AddProduct d345;12.3;Dell",
			"AddProduct t03;712.3;Toshiba", "AddProduct l61;11.3;Lenovo", "AddProduct l51;12.3;Lenovo",
			"AddProduct m61;15.3;MSI", "AddProduct t52;16.31;Toshiba", "AddProduct t61;12.3;Toshiba",
			"AddProduct t13;2.3;Toshiba", "AddProduct t92;125.3;Toshiba", "AddProduct t37;312.3;Toshiba",
			"AddProduct t03;712.3;Toshiba", "AddProduct t44;116.3;Toshiba", "AddProduct d123;24.3;Dell",
			"AddProduct d234;98.3;Dell", "AddProduct d345;12.3;Dell", "AddProduct t03;712.3;Toshiba",
		},
		new string[]
		{
			"FindProductsByName t13", "FindProduct d234", "FindProduct t03", "FindProduct d123",
			"FindProductsByName t14", "FindProduct d123", "FindProduct l61", "FindProduct l51",
		},
		new string[]
		{
			"DeleteProducts t52;Toshiba", "DeleteProduct Toshiba", "DeleteProduct l52;Toshiba",
			"DeleteProducts Toshiba", "DeleteProduct l51", "DeleteProduct t03;Toshiba",
			"DeleteProducts  d123;Dell",
		}
	};

        public static void FillInputFileWithMaxCommands(int n = 1000000)
        {
            Console.WriteLine("start filling the input file");
            using (var writer = new StreamWriter(inputFileName))
            {
                foreach (var command in commands[0])
                {
                    writer.WriteLine(command);
                    n--;
                }

                for (int i = 0; i < n; i++)
                {
                    int section = rand.Next(commands.Length);
                    string[] currentCommands = commands[section];
                    foreach (var command in currentCommands)
                    {
                        writer.WriteLine(command);
                        i++;
                    }
                }
            }

            Console.WriteLine("finished filling the input file");
        }
    }
}
