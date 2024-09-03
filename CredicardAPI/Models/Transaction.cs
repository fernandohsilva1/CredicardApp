namespace CredicardAPI.Models
{
    public class Transaction
    {
        public string CardNumber { get; set; } = string.Empty;
        public string CardBrand { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Cvc { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string? TransactionId { get; set; }
    }
}
