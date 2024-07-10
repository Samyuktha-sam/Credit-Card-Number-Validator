using System.Linq;
using CreditcardValidatorAPI.Models;

namespace CreditcardValidatorAPI.Repositories;


public class ValidationRepository : IValidationRepository
{
    private readonly CCVDbContext _context;

    public ValidationRepository(CCVDbContext context)
    {
        _context = context;
    }

    public void AddValidationRequest(ValidationRequest validationRequest)
    {
        _context.ValidationRequests.Add(validationRequest);
        _context.SaveChanges();
    }

    public string GetCardType(string creditCardNumber)
    {
        var cardType = _context.CardTypes
            .FirstOrDefault(card => creditCardNumber.StartsWith(card.Prefix) && creditCardNumber.Length == card.Length);

        return cardType?.CardTypeName ?? "Unknown";
    }

}
