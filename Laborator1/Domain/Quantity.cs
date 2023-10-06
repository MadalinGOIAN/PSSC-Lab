using CSharp.Choices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laborator1.Domain;

[AsChoice]
public static partial class Quantity
{
    public interface IQuantity { }

    public record Units(int number) : IQuantity
    {
        public override string ToString() => $"{number}u";
    }

    public record Kilograms(double number) : IQuantity
    {
        public override string ToString() => $"{number}kg";
    }

    public record Undefined(string value) : IQuantity
    {
        public override string ToString() => $"{value} is undefined";
    }

    public static IQuantity ConvertToQuantity(string quantity)
    {
        if (int.TryParse(quantity, out var units))
            return new Units(units);
        else if (double.TryParse(quantity, out var kilograms))
            return new Kilograms(kilograms);
        else return new Undefined(quantity);
    }
}
