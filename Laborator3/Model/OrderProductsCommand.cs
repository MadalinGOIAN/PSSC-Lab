namespace Laborator3.Model;

public record OrderProductsCommand
{
    public OrderProductsCommand(IReadOnlyCollection<UnvalidatedOrderedProduct> inputOrderedProducts)
        => InputOrderedProducts = inputOrderedProducts;

    public IReadOnlyCollection<UnvalidatedOrderedProduct> InputOrderedProducts { get; }
}
