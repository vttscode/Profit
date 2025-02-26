using Profit.Model;

namespace Profit.Services.CalculateData
{
    /// <summary>
    /// Calculates the realized profit or loss for a given client using the FIFO method.
    /// </summary>
    public class ProfitLossCalculator
    {
        /// <summary>
        /// Calculates the realized profit or loss for each security traded by the specified client up to a given date.
        /// </summary>
        /// <param name="trades">A list of trades to process.</param>
        /// <param name="client">The client for whom profit/loss should be calculated.</param>
        /// <param name="date">The cutoff date for trade inclusion.</param>
        /// <returns>A dictionary where the key is the security name and the value is the total realized profit or loss.</returns>
        public Dictionary<string, decimal> Calculate(List<Trade> trades, string client, DateTime date)
        {
            var sortedTrades = trades
                .Where(t => t.Client == client && t.Date <= date)
                .OrderBy(t => t.Date)
                .ToList();

            var securityHoldings = new Dictionary<string, Queue<(int, decimal)>>();
            var profitLoss = new Dictionary<string, decimal>();

            foreach (var trade in sortedTrades)
            {
                decimal totalCost = trade.Price * trade.Amount + (trade.Type == "BUY" ? trade.Fee : 0);
                decimal totalRevenue = trade.Price * trade.Amount - (trade.Type == "SELL" ? trade.Fee : 0);

                if (trade.Type == "BUY")
                {
                    if (!securityHoldings.ContainsKey(trade.Security))
                        securityHoldings[trade.Security] = new Queue<(int, decimal)>();

                    securityHoldings[trade.Security].Enqueue((trade.Amount, totalCost / trade.Amount));
                }
                else if (trade.Type == "SELL")
                {
                    if (!securityHoldings.ContainsKey(trade.Security)) continue;

                    int amountToSell = trade.Amount;
                    decimal sumOfSold = 0;

                    while (amountToSell > 0 && securityHoldings[trade.Security].Count > 0)
                    {
                        var (amountOwned, buyPrice) = securityHoldings[trade.Security].Dequeue();
                        int quantitySold = Math.Min(amountOwned, amountToSell);
                        sumOfSold += quantitySold * (trade.Price - buyPrice);
                        amountToSell -= quantitySold;

                        if (amountOwned > quantitySold)
                        {
                            securityHoldings[trade.Security].Enqueue((amountOwned - quantitySold, buyPrice));
                        }
                    }

                    if (!profitLoss.ContainsKey(trade.Security))
                        profitLoss[trade.Security] = 0;

                    profitLoss[trade.Security] += sumOfSold - trade.Fee;
                }
            }

            return profitLoss;
        }
    }
}

