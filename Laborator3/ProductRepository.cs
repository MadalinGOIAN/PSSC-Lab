using Laborator3.Model;

namespace Laborator3;

public static class ProductRepository
{
    public static List<Product> AvailableProducts = new()
    {
        new Product { ProductCode = new ProductCode("1111111111"), Price = new Price(9.99M) },
        new Product { ProductCode = new ProductCode("22222222222"), Price = new Price(14.49M) },
        new Product { ProductCode = new ProductCode("333333333333"), Price = new Price(2.09M) },
        new Product { ProductCode = new ProductCode("12345678910"), Price = new Price(17.89M) },
        new Product { ProductCode = new ProductCode("1212121212121"), Price = new Price(1.99M) },
        new Product { ProductCode = new ProductCode("101010101010"), Price = new Price(5.45M) },
        new Product { ProductCode = new ProductCode("0000000000"), Price = new Price(0.99M) },
        new Product { ProductCode = new ProductCode("0000000001"), Price = new Price(8.99M) },
        new Product { ProductCode = new ProductCode("0000000002"), Price = new Price(10.65M) },
        new Product { ProductCode = new ProductCode("0000000000001"), Price = new Price(23.59M) }
    };
}
