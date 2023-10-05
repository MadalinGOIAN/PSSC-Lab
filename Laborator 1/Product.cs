namespace PSSC_Lab;

public record Product
{
    public string ProductCode { get; set; }
    public IQuantity Quantity { get; }
}
