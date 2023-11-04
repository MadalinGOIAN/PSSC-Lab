using Laborator3.Model.Exceptions;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Laborator3.Model;

public record Quantity
{
    public int Value { get; }

    internal Quantity(int value)
    {
        if (IsValid(value))
            Value = value;
        else throw new InvalidQuantityException($"{value} is an invalid quantity.");
    }

    public override string ToString() => Value.ToString();

    public static Option<Quantity> TryParse(string stringQuantity)
    {
        if (int.TryParse(stringQuantity, out int numericQuantity) && IsValid(numericQuantity))
            return Some(new Quantity(numericQuantity));

        return None;
    }

    private static bool IsValid(int numericQuantity) => numericQuantity > 0;
}
