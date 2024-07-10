using CreditcardValidatorAPI.Models;
using CreditcardValidatorAPI.Repositories;

namespace CreditcardValidatorAPI.Services;

public class ValidationService : IValidationService
{
    private readonly IValidationRepository _repository;

    public ValidationService(IValidationRepository repository)
    {
        _repository = repository;
    }

    public (bool isValid, string cardType) ValidateCreditCard(string creditCardNumber)
    {
        var cardType = _repository.GetCardType(creditCardNumber);
        var isValid = ValidateLuhnAlgorithm(creditCardNumber);
        
        return (isValid, cardType);
    }

    public void AddValidationRequest(ValidationRequest validationRequest)
    {
        _repository.AddValidationRequest(validationRequest);
    }

    private bool ValidateLuhnAlgorithm(string creditCardNumber)
    {
        int sum = 0;
        bool alternate = false;
        for (int i = creditCardNumber.Length - 1; i >= 0; i--)
        {
            int n = int.Parse(creditCardNumber[i].ToString());
            if (alternate)
            {
                n *= 2;
                if (n > 9)
                    n -= 9;
            }
            sum += n;
            alternate = !alternate;
        }
        return (sum % 10 == 0);
    }
}
