namespace Profit.Model
{
    /// <summary>
    /// Represents a financial trade transaction.
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// Gets or sets the unique trade identifier.
        /// </summary>
        public int TradeId { get; set; }

        /// <summary>
        /// Gets or sets the trade type (e.g., "BUY" or "SELL").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets "BUY","SELL" type.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the client associated with the trade.
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// Gets or sets the security (stock, bond, etc.) being traded.
        /// </summary>
        public string Security { get; set; }

        /// <summary>
        /// Gets or sets the number of securities traded.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the price per unit of the security.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the transaction fee applied to the trade.
        /// </summary>
        public decimal Fee { get; set; }
    }
}
