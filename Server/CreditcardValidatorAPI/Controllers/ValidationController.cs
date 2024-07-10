using Microsoft.AspNetCore.Mvc;
using CreditcardValidatorAPI.Models;
using CreditcardValidatorAPI.Services;

namespace CreditcardValidatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly IValidationService _validationService;

        public ValidationController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        [HttpPost]
        public IActionResult ValidateCreditCard([FromBody] ValidationRequestDTO requestDTO)
        {
            string? creditCardNumber = requestDTO.creditCardNumber;

            if (string.IsNullOrEmpty(creditCardNumber))
                return BadRequest("Credit card number is required.");

            var (isValid, cardType, message) = _validationService.ValidateCreditCard(creditCardNumber);

            return Ok(new
            {
                isValid,
                cardType,
                message
            });
        }
    }
}
