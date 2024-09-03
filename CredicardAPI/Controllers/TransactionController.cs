using Microsoft.AspNetCore.Mvc;
using CredicardAPI.Models;
using System.Xml.Serialization;
using CrediCardAPI.Utils;
using CredicardAPI.Services;

namespace CredicardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly CieloService _cieloService;

        public TransactionController(CieloService cieloService)
        {
            _cieloService = cieloService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Transaction transaction)
        {
            if (!CardValidator.IsValidCard(transaction.CardNumber, transaction.CardBrand, transaction.Cvc))
            {
                return BadRequest("Formato do cartão inválido, verifique os campos e preencha novamente.");
            }

            var transactionId = Guid.NewGuid().ToString();

            transaction.TransactionId = transactionId;

            var result = await _cieloService.CreateTransaction(transaction);

            return Ok(new { TransactionId = transactionId, Response = result });
        }

        [HttpPut("capture/{transactionId}")]
        public async Task<IActionResult> Capture(string transactionId, [FromQuery] decimal amount)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                return BadRequest("ID da transação é obrigatório.");
            }

            if (amount <= 0)
            {
                return BadRequest("Valor deve ser maior que zero.");
            }

            if (amount > 10000000)
            {
                return BadRequest("Valor para transação maior que o permitido");
            }

            var result = await _cieloService.CaptureTransaction(transactionId, amount);
            return Ok(result);
        }

        [HttpPut("cancel/{transactionId}")]
        public async Task<IActionResult> Cancel(string transactionId, [FromQuery] decimal? amount)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                return BadRequest("ID da transação é obrigatório.");
            }

            var result = await _cieloService.CancelTransaction(transactionId, amount);
            return Ok(result);
        }

    }
}
