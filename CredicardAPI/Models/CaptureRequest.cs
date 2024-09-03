namespace CredicardAPI.Models
{
    public class CaptureRequest
    {
        public string TransactionId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
