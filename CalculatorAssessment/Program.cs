using CalculatorAssessment.BusinessLogic;
using CalculatorAssessment.Model;
using System;
using System.Threading.Tasks;

namespace CalculatorAssessment
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var fees = await ReadFromJson.FetchFees();

            ExpectedCharge(fees);
            AdvisedDebitAmount(fees);
        }

        private static void ExpectedCharge(ListOfFees fees)
        {
            Console.WriteLine("Please enter amount: ");
            var input = Console.ReadLine();
            double amount = 0;
            double result = 0;
            if (double.TryParse(input, out double res))
            {
                amount = res;
            }

            foreach (Fee fee in fees.Fees)
            {
                if (amount >= fee.MinAmount && amount <= fee.MaxAmount)
                {
                    result = fee.FeeAmount;
                }
            }
            Console.Write("Expected charge is: ");
            Console.WriteLine(result);
        }

        private static void AdvisedDebitAmount(ListOfFees fees)
        {
            Console.WriteLine("Please enter amount: ");
            var input = Console.ReadLine();
            double amount = 0;
            double advisedAmount = 0;
            if (double.TryParse(input, out double res))
            {
                amount = res;
            }

            foreach (Fee fee in fees.Fees)
            {
                if (amount >= fee.MinAmount && amount <= fee.MaxAmount)
                {
                    advisedAmount = amount - fee.FeeAmount;
                }
            }
            Console.Write("Advised amount is: ");
            Console.WriteLine(advisedAmount);
            Console.Write("Debit amount is: ");
            Console.WriteLine(amount);
        }
    }
}
