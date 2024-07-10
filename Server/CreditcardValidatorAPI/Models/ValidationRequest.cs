using System;
using System.Collections.Generic;

namespace CreditcardValidatorAPI.Models;

public partial class ValidationRequest
{
    public int RequestId { get; set; }
    public string CreditCardNumber { get; set; } = null!;
    public bool IsValid { get; set; }
    public string? CardType { get; set; }
    public string? ResultMsg { get; set; }
    public DateTime? Timestamp { get; set; }
}
