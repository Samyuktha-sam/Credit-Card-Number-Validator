using CreditcardValidatorAPI.Models;

namespace CreditcardValidatorAPI.Repositories;
public interface IValidationRepository
{
    void AddValidationRequest(ValidationRequest validationRequest);
    string GetCardType(string creditCardNumber);
}
