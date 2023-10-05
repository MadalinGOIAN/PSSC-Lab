namespace PSSC_Lab;

public class Kilograms : IQuantity
{
    public double Number { get; set; }

    public Kilograms(double nr) => Number = nr;
}
