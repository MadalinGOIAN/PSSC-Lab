using static Laborator1.Domain.Quantity;

namespace Laborator1.Domain;

public record Product
{
    public string Code { get; set; }
    public IQuantity Quantity { get; init; }

    public override string ToString()
    {
        return "Cod produs: " + Code + ", Cantitate: " +
            Quantity.Match(whenUnits: units => units,
                           whenKilograms: kilograms => kilograms,
                           whenUndefined: undefined => undefined).ToString();
    }
}
