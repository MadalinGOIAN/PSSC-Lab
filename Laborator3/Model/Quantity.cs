using Laborator3.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public static bool TryParseQuantity(string stringQuantity, out Quantity quantity)
    {
        bool isValid = false;
        quantity = null;

        if (int.TryParse(stringQuantity, out int numericQuantity))
        {
            if (IsValid(numericQuantity))
            {
                isValid = true;
                quantity = new(numericQuantity);
            }
        }

        return isValid;
    }

    private static bool IsValid(int numericQuantity) => numericQuantity > 0;
}
