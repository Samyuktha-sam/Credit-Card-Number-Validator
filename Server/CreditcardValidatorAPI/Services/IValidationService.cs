using CreditcardValidatorAPI.Models;

namespace CreditcardValidatorAPI.Services;
public interface IValidationService
{
    (bool isValid, string cardType, string resultMsg) ValidateCreditCard(string creditCardNumber);
}
