using Laborator3.Model.Exceptions;
using System.Text.RegularExpressions;

namespace Laborator3.Model;

public record ProductCode
{
    private static readonly Regex ValidPattern = new("^[0-9]{10,13}$");
    public string Value { get; }

    internal ProductCode(string value)
    {
        if (IsValid(value))
            Value = value;
        else throw new InvalidProductCodeException("The product code needs to have between 10 and 13 digits!");
    }

    private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);

    public override string ToString() => Value;

    public static bool TryParse(string stringValue, out ProductCode productCode)
    {
        bool isValid = false;
        productCode = null;

        if (IsValid(stringValue))
        {
            isValid = true;
            productCode = new(stringValue);
        }

        return isValid;
    }
}
