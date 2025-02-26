using Profit.Model;
using Profit.Services.CalculateData;
using Profit.Services.InputData;
using Profit.Services.PrintData;
using Profit.Services.ReadData;
using Profit.Services.SaveData;

class Program
{
    static void Main(string[] args)
    {
        UserInputHandler userInputHandler = new ();
        string filePath = userInputHandler.GetFilePath();
        string client = userInputHandler.GetClient();
        DateTime date = userInputHandler.GetDate();

        InputPrinter inputPrinter = new ();
        inputPrinter.PrintParams(client, date, filePath);

        TradeDataReader tradeDataReader = new ();    
        List<Trade> trades = tradeDataReader.ReadTradesFromFile(filePath);

        ProfitLossCalculator profitLossCalculator = new ();
        var result = profitLossCalculator.Calculate(trades, client, date);

        ResultPrinter resultPrinter = new ();
        resultPrinter.PrintResults(result);

        ResultSaver resultSaver = new ();
        resultSaver.SaveToFile(result);

    }   
}


