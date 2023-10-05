namespace PSSC_Lab;

public class Undefined : IQuantity
{
    public string Received { get; set; }

    public Undefined(string recv) => Received = recv;
}
