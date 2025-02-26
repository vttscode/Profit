namespace Profit.Services.SaveData
{
    // To do full validation

    /// <summary>
    /// Handles saving calculation results to a file.
    /// </summary>
    public class ResultSaver
    {
        private readonly string _outputFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultSaver"/> class with an optional output file path.
        /// </summary>
        /// <param name="outputFilePath">The file path where results will be saved. Defaults to the desktop if not provided.</param>
        public ResultSaver(string outputFilePath = null)
        {
            _outputFilePath = outputFilePath ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "out.txt");
        }

        /// <summary>
        /// Saves the profit/loss results to a file.
        /// </summary>
        /// <param name="result">A dictionary containing security names as keys and profit/loss values as values.</param>
        public void SaveToFile(Dictionary<string, decimal> result)
        {
            try
            {
                File.WriteAllLines(_outputFilePath, result.Select(r => $"{r.Key};{r.Value:F2}"));
                Console.WriteLine($"Results successfully saved: {_outputFilePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving results to file: {ex.Message}");
            }
        }
    }
}
