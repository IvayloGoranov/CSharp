using CalculatorAsyncInvoke.ServiceCalculator;
using System;

namespace CalculatorAsyncInvoke
{
    class InvokeCalculatorAsync
    {
        private static ServiceCalculatorClient calculatorClient = 
            new ServiceCalculatorClient();

        public static async void Main()
        {
            //calculatorClient.BeginCalculate(
            //    3, 5, CalculationOperation.Add, CalculationFinished, null);

            int result = await calculatorClient.CalculateAsync(3, 5, CalculationOperation.Add);
            Console.WriteLine("Service invoked asynchronously.");
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();

            Console.WriteLine("The result returned by the WCF service is: " + result);
        }

        //static void CalculationFinished(IAsyncResult asyncResult)
        //{
        //    int result = calculatorClient.EndCalculate(asyncResult);
        //    Console.WriteLine("The result returned by the WCF service is: " + result);
        //}
    }
}
