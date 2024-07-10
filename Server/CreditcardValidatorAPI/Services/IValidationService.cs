using CreditcardValidatorAPI.Models;

namespace CreditcardValidatorAPI.Services;
public interface IValidationService
{
    (bool isValid, string cardType) ValidateCreditCard(string creditCardNumber);
    void AddValidationRequest(ValidationRequest validationRequest);
}
