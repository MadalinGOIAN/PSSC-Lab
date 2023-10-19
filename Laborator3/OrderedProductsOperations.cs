using Laborator3.Model;
using System.Text;
using static Laborator3.Model.OrderedProducts;

namespace Laborator3;

public static class OrderedProductsOperations
{
    public static IOrderedProducts ValidateOrderedProducts(Func<ProductCode, bool> checkProductExists,
                                                           Func<Quantity, bool> checkProductIsInStock,
                                                           UnvalidatedOrderedProducts orderedProducts)
    {
        List<ValidatedOrderedProduct> validatedProducts = new();
        bool isValidList = true;
        string invalidReason = string.Empty;

        foreach (var unvalidatedProduct in orderedProducts.ProductList)
        {
            if(!ProductCode.TryParse(unvalidatedProduct.ProductCode, out ProductCode productCode)
                && checkProductExists(productCode))
            {
                invalidReason = $"Invalid product code ({unvalidatedProduct.ProductCode})";
                isValidList = false;
                break;
            }

            if(!Quantity.TryParseQuantity(unvalidatedProduct.Quantity, out Quantity quantity)
                && checkProductIsInStock(quantity))
            {
                invalidReason = $"Insufficient stock";
                isValidList = false;
                break;
            }

            validatedProducts.Add(new(productCode, quantity));
        }
        
        if (isValidList)
            return new ValidatedOrderedProducts(validatedProducts);
        else return new InvalidatedOrderedProducts(orderedProducts.ProductList, invalidReason);
    }

    public static IOrderedProducts CalculateOrderedProducts(IOrderedProducts orderedProducts)
        => orderedProducts.Match(whenUnvalidatedOrderedProducts: unvalidatedProducts => unvalidatedProducts,
                                 whenInvalidatedOrderedProducts: invalidatedProducts => invalidatedProducts,
                                 whenCalculatedOrderedProducts: calculatedProducts => calculatedProducts,
                                 whenPublishedOrderedProducts: publishedProducts => publishedProducts,
                                 whenValidatedOrderedProducts: validatedProducts =>
    {
        var calculatedProducts = validatedProducts.ProductList.Select(validProduct =>
            new CalculatedOrderedProduct(validProduct.ProductCode,
                                         validProduct.Quantity,
                                         CalculateTotalPrice(validProduct)));
        
        return new CalculatedOrderedProducts(calculatedProducts.ToList().AsReadOnly());
    });

    public static IOrderedProducts PublishOrderedProducts(IOrderedProducts orderedProducts)
        => orderedProducts.Match(whenUnvalidatedOrderedProducts: unvalidatedProducts => unvalidatedProducts,
                                 whenInvalidatedOrderedProducts: invalidatedProducts => invalidatedProducts,
                                 whenPublishedOrderedProducts: publishedProducts => publishedProducts,
                                 whenValidatedOrderedProducts: validatedProducts => validatedProducts,
                                 whenCalculatedOrderedProducts: calculatedProducts =>
    {
        StringBuilder csv = new();
        calculatedProducts.ProductList.Aggregate(csv, (export, product)
            => export.AppendLine($"{product.ProductCode.Value}, {product.Quantity.Value}, {product.TotalPrice.Value}"));

        PublishedOrderedProducts publishedOrderedProducts = new(calculatedProducts.ProductList, csv.ToString(), DateTime.Now);

        return publishedOrderedProducts;
    });

    private static Price CalculateTotalPrice(ValidatedOrderedProduct validProduct)
        => new Price(ProductRepository.AvailableProducts.Find(product
            => product.ProductCode.Equals(validProduct.ProductCode)).Price.Value * validProduct.Quantity.Value);
}
