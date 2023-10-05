namespace PSSC_Lab;

public record Command
{
    public Person Person { get; set; }
    public List<Product> ProductsList { get; set; }
}
