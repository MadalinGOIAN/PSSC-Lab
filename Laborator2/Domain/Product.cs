namespace Laborator2.Domain;

public record Product
{
    public int Quantity { get; set; }
    public string Code { get; set; }
    public string Address { get; set; }
}
