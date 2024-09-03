namespace CredicardAPI.Models
{
    public class CancelRequest
    {
        public string TransactionId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
