namespace Profit.Services.PrintData
{
    using System;

    /// <summary>
    /// Handles printing of input parameters to the console.
    /// </summary>
    public class InputPrinter
    {
        /// <summary>
        /// Prints the provided input parameters (client name, date, and file path) to the console.
        /// </summary>
        /// <param name="client">The name of the client.</param>
        /// <param name="date">The selected date.</param>
        /// <param name="filePath">The path to the data file.</param>
        public void PrintParams(string client, DateTime date, string filePath)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Įvesti parametrai:");
            Console.WriteLine($"Duomenų failo kelias: {filePath}");
            Console.WriteLine($"Klientas: {client}");
            Console.WriteLine($"Data: {date:yyyy-MM-dd}");                       
            Console.WriteLine("====================================");
            Console.WriteLine("");
        }
    }
}
