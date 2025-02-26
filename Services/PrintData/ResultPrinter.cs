namespace Profit.Services.PrintData
{
    /// <summary>
    /// Responsible for printing profit/loss results to the console.
    /// </summary>
    public class ResultPrinter    
    {
        // To do full validation

        /// <summary>
        /// Prints the profit/loss results in a table format to the console.
        /// </summary>
        /// <param name="result">A dictionary where the key is the security name, and the value is the profit or loss amount.</param>
        public void PrintResults(Dictionary<string, decimal> result)
        {
            Console.WriteLine("Security\tProfit/Loss");
            Console.WriteLine("------------------------------------");
            foreach (var entry in result)
            {
                Console.WriteLine($"{entry.Key}\t{entry.Value:F2}");
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("====================================");
        }

    }
}
