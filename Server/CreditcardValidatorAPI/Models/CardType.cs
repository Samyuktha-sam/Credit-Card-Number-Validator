using System;
using System.Collections.Generic;

namespace CreditcardValidatorAPI.Models;

public partial class CardType
{
    public int CardTypeId { get; set; }
    public string CardTypeName { get; set; } = null!;
    public string Prefix { get; set; } = null!;
    public int Length { get; set; }
}
