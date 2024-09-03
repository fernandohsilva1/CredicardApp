using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CredicardAPI.Models;

namespace CredicardAPI.Services
{
    public class CieloService
    {
        private readonly RestClient _client;
        private readonly string _merchantId;
        private readonly string _merchantKey;

        public CieloService()
        {
            _client = new RestClient("https://sandbox.cieloecommerce.cielo.com.br/");
            _merchantId = "fe18b43c-ff80-4cfe-80ba-b2b05a42c002";
            _merchantKey = "DCUIFCRIFUMTXIADCGKRLYYEUDSMFGTYMXYHZFCN";
        }

        public async Task<string> CreateTransaction(Transaction transaction)
        {
            var request = new RestRequest("1/sales", Method.Post);

            request.AddHeader("MerchantId", _merchantId);
            request.AddHeader("MerchantKey", _merchantKey);

            request.AddJsonBody(new
            {
                MerchantOrderId = "1234",
                Customer = new
                {
                    Name = "John Doe",
                    Email = "john.doe@example.com"
                },
                Payment = new
                {
                    Type = "CreditCard",
                    Amount = (int)(transaction.Amount * 100),
                    Installments = 1,
                    CreditCard = new
                    {
                        Number = transaction.CardNumber,
                        Holder = "John Doe",
                        ExpirationDate = "12/2025",
                        SecurityCode = transaction.Cvc,
                        Brand = transaction.CardBrand
                    },
                    SoftDescriptor = "Payment"
                }
            });

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }

        public async Task<string> CaptureTransaction(string transactionId, decimal amount)
        {
            var request = new RestRequest($"1/sales/{transactionId}/capture", Method.Put);

            request.AddHeader("MerchantId", _merchantId);
            request.AddHeader("MerchantKey", _merchantKey);

            request.AddJsonBody(new
            {
                Amount = (int)(amount * 100)
            });

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }


        public async Task<string> CancelTransaction(string transactionId, decimal? amount)
        {
            var request = new RestRequest($"1/sales/{transactionId}/void", Method.Put);

            request.AddHeader("MerchantId", _merchantId);
            request.AddHeader("MerchantKey", _merchantKey);

            if (amount.HasValue)
            {
                request.AddQueryParameter("amount", (int)(amount.Value * 100));
            }

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
