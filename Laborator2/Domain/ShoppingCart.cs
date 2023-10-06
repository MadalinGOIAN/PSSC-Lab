using CSharp.Choices;

namespace Laborator2.Domain;

[AsChoice]
public static partial class ShoppingCart
{
    public interface IShoppingCart { }
    public record EmptyCart() : IShoppingCart;
    public record UnvalidatedCart(IReadOnlyCollection<UnvalidatedProduct> productList) : IShoppingCart;
    public record ValidatedCart(IReadOnlyCollection<ValidatedProduct> productList) : IShoppingCart;
    public record PaidCart(IReadOnlyCollection<ValidatedProduct> productList) : IShoppingCart;
}
