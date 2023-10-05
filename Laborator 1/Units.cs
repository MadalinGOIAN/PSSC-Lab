namespace PSSC_Lab;

public class Units : IQuantity
{
    public int Number { get; set; }

    public Units(int nr) => Number = nr;
}
