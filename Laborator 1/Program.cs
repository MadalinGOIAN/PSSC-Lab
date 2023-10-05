using PSSC_Lab;

internal class Program
{
    private static void Main(string[] args)
    {
        IQuantity quantity = ConvertToQuantity("2");

        quantity.Match(
            whenKilograms: kilograms => kilograms,
            whenUndefined: undefined => undefined,
            whenUnits: units => Print(units)
        );
    }

    private static IQuantity ConvertToQuantity(string sal)
    {
        if (int.TryParse(sal, out int units))
            return new Units(units);
        else if (double.TryParse(sal, out double kgs))
            return new Kilograms(kgs);
        else return new Undefined(sal);
    }

    private static Units Print(Units units)
    {
        Console.WriteLine($"{units.Number}u");
        return units;
    }
}
