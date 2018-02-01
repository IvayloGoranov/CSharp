using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using ShoppingCenter;

namespace ShoppingCenter.Tests
{
    [TestClass]
    public class UnitTestsShoppingCenter
    {
        private void ExecuteTest(string inputFileName, string outputFileName)
        {
            var shoppingCenter = new ShoppingCenterFast();
            var inputCommands = File.ReadAllLines(@"..\..\..\Judge-Tests\" + inputFileName);
            var output = new StringBuilder();
            int commandsCount = int.Parse(inputCommands[0]);
            for (int i = 1; i <= commandsCount; i++)
            {
                string command = inputCommands[i];
                if (!string.IsNullOrEmpty(command))
                {
                    var commandOutput = shoppingCenter.ProcessCommand(command);
                    output.AppendLine(commandOutput);
                }
            }

            var expectedOutput = File.ReadAllText(@"..\..\..\Judge-Tests\" + outputFileName);
            var actualOutput = output.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [Timeout(100)]
        public void Test000_SampleInput()
        {
            ExecuteTest("test.000.001.in.txt", "test.000.001.out.txt");
        }

        [TestMethod]
        [Timeout(100)]
        public void Test001_Add()
        {
            ExecuteTest("test.001.in.txt", "test.001.out.txt");
        }

        [TestMethod]
        [Timeout(100)]
        public void Test002_Add_FindByName()
        {
            ExecuteTest("test.002.in.txt", "test.002.out.txt");
        }

        [TestMethod]
        [Timeout(100)]
        public void Test003_Add_FindByProducer()
        {
            ExecuteTest("test.003.in.txt", "test.003.out.txt");
        }

        [TestMethod]
        [Timeout(100)]
        public void Test004_Add_FindByPriceRange()
        {
            ExecuteTest("test.004.in.txt", "test.004.out.txt");
        }

        [TestMethod]
        [Timeout(100)]
        public void Test005_Add_DeleteByProducer()
        {
            ExecuteTest("test.005.in.txt", "test.005.out.txt");
        }

        [TestMethod]
        [Timeout(100)]
        public void Test006_Add_DeleteByNameAndProducer()
        {
            ExecuteTest("test.006.in.txt", "test.006.out.txt");
        }

        [TestMethod]
        [Timeout(100)]
        public void Test007_MixOf44Commands()
        {
            ExecuteTest("test.007.in.txt", "test.007.out.txt");
        }

        [TestMethod]
        [Timeout(100)]
        public void Test008_MixOf1050Commands()
        {
            ExecuteTest("test.008.in.txt", "test.008.out.txt");
        }

        [TestMethod]
        [Timeout(250)]
        public void Test009_Performance_MixOf_10048_Commands()
        {
            ExecuteTest("test.009.in.txt", "test.009.out.txt");
        }

        [TestMethod]
        [Timeout(2000)]
        public void Test010_Performance_MixOf_20000_Commands()
        {
            ExecuteTest("test.010.in.txt", "test.010.out.txt");
        }

        [TestMethod]
        [Timeout(1000)]
        public void Test011_Performance_Add_FindByName()
        {
            ExecuteTest("test.011.in.txt", "test.011.out.txt");
        }

        [TestMethod]
        [Timeout(1000)]
        public void Test012_Performance_Add_FindByProducer()
        {
            ExecuteTest("test.012.in.txt", "test.012.out.txt");
        }

        [TestMethod]
        [Timeout(1000)]
        public void Test013_Performance_Add_FindByPriceRange()
        {
            ExecuteTest("test.013.in.txt", "test.013.out.txt");
        }

        [TestMethod]
        [Timeout(1000)]
        public void Test014_Performance_Add_DeleteByProducer()
        {
            ExecuteTest("test.014.in.txt", "test.014.out.txt");
        }

        [TestMethod]
        [Timeout(1000)]
        public void Test015_Performance_Add_DeleteByNameAndProducer()
        {
            ExecuteTest("test.015.in.txt", "test.015.out.txt");
        }
    }
}
