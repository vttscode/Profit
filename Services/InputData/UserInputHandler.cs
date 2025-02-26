using System.Globalization;

namespace Profit.Services.InputData
{


    /// <summary>
    /// Handles user input for client name, date, and file path, ensuring valid data entry.
    /// </summary>
    public class UserInputHandler
    {
        // To do full validation
        
        /// <summary>
        /// Prompts the user to enter a client name and ensures it is not empty.
        /// </summary>
        /// <returns>The validated client name.</returns>
        public string GetClient()
        {
            string client;
            do
            {
                Console.Write("Įveskite klientą: ");
                client = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(client))
                {
                    Console.WriteLine("Klaida: Kliento vardas negali būti tuščias.");
                }
            } while (string.IsNullOrEmpty(client));

            return client;
        }

        // To do full validation

        /// <summary>
        /// Prompts the user to enter a date in "YYYY-MM-DD" format and ensures correct formatting.
        /// </summary>
        /// <returns>The validated DateTime object.</returns>
        public DateTime GetDate()
        {
            string dateInput;
            DateTime date;
            do
            {
                Console.Write("Enter date (YYYY-MM-DD): ");
                dateInput = Console.ReadLine().Trim();

                if (!DateTime.TryParseExact(dateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine("Error: Invalid date format. Use YYYY-MM-DD.");
                }
            } while (!DateTime.TryParseExact(dateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date));

            return date;
        }

        // To do full validation

        /// <summary>
        /// Prompts the user to enter a file path and ensures that the specified file exists.
        /// </summary>
        /// <returns>The validated file path as a string.</returns>
        public string GetFilePath()
        {
            string filePath;
            do
            {
                Console.Write("Enter data file path: ");
                filePath = Console.ReadLine().Trim('"');

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Error: The specified file does not exist. Please try again.");
                }
            } while (!File.Exists(filePath));

            return filePath;
        }
    }
}
