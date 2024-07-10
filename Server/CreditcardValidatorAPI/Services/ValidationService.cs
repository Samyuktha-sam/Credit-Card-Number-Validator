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

    public (bool isValid, string cardType, string resultMsg) ValidateCreditCard(string creditCardNumber)
    {
        try
        {
            var cardType = _repository.GetCardType(creditCardNumber);

            if (cardType == "Unknown")
            {
                throw new ArgumentException("Card type is unknown. Validation stopped.");
            }

            var isValid = ValidateLuhnAlgorithm(creditCardNumber);
            if(!isValid){
                cardType = "Not Applicable";
            }
            var resultMsg = isValid
                ? $"Credit card is valid. Card Type: {cardType}"
                : $"Credit card number is invalid.";

            LogValidationRequest(creditCardNumber, isValid, cardType, resultMsg);

            return (isValid, cardType, resultMsg);
        }
        catch (Exception ex)
        {
            var cardType = "Unknown";
            var resultMsg = ex is ArgumentException ? ex.Message : $"An error occurred during validation: {ex.Message}";

            LogValidationRequest(creditCardNumber, false, cardType, resultMsg);

            return (false, cardType, resultMsg);
        }
    }

    private void LogValidationRequest(string creditCardNumber, bool isValid, string cardType, string resultMsg)
    {
        var validationRequest = new ValidationRequest
        {
            CreditCardNumber = creditCardNumber,
            IsValid = isValid,
            CardType = cardType,
            Timestamp = DateTime.Now,
            ResultMsg = resultMsg
        };

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
