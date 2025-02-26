using System.Globalization;
using Profit.Model;

namespace Profit.Services.ReadData
{   
    // To do full validation

    /// <summary>
    /// Handles reading trade data from a CSV file and parsing it into a list of Trade objects.
    /// </summary>
    public class TradeDataReader
    {
        /// <summary>
        /// Reads trade data from a CSV file and returns a list of Trade objects.
        /// </summary>
        /// <param name="filePath">The path to the CSV file containing trade data.</param>
        /// <returns>A list of <see cref="Trade"/> objects parsed from the file.</returns>
        public List<Trade> ReadTradesFromFile(string filePath)
        {
            var trades = new List<Trade>();

            try
            {
                var lines = File.ReadAllLines(filePath);
                if (lines.Length < 2)
                {
                    Console.WriteLine("Error: The file does not contain sufficient data.");
                    return trades;
                }

                string[] headers = lines[0].Split(';');
                var culture = CultureInfo.GetCultureInfo("lt-LT");

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(';');

                    if (!int.TryParse(GetFieldValue(headers, fields, "TradeId"), out int tradeId) ||
                        !DateTime.TryParseExact(GetFieldValue(headers, fields, "Date"), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tradeDate) ||
                        !int.TryParse(GetFieldValue(headers, fields, "Amount"), out int amount) ||
                        !decimal.TryParse(GetFieldValue(headers, fields, "Price"), NumberStyles.Any, culture, out decimal price) ||
                        !decimal.TryParse(GetFieldValue(headers, fields, "Fee"), NumberStyles.Any, culture, out decimal fee))
                    {
                        Console.WriteLine($"Skipped invalid row {i + 1} in the file.");
                        continue;
                    }

                    var trade = new Trade
                    {
                        TradeId = tradeId,
                        Type = GetFieldValue(headers, fields, "Type"),
                        Date = tradeDate,
                        Client = GetFieldValue(headers, fields, "Client"),
                        Security = GetFieldValue(headers, fields, "Security"),
                        Amount = amount,
                        Price = price,
                        Fee = fee
                    };
                    trades.Add(trade);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }

            return trades;
        }

        // To do full validation

        /// <summary>
        /// Retrieves the value of a specified column from a row in the CSV file.
        /// </summary>
        /// <param name="headers">The header row of the CSV file.</param>
        /// <param name="fields">The current row being processed.</param>
        /// <param name="columnName">The column name to extract.</param>
        /// <returns>The value from the specified column, or an empty string if the column is not found.</returns>
        private string GetFieldValue(string[] headers, string[] fields, string columnName)
        {
            int index = Array.IndexOf(headers, columnName);
            return index >= 0 && index < fields.Length ? fields[index] : "";
        }
    }
}
