using Laborator3.Model;
using static Laborator3.Model.OrderedProducts;
using static Laborator3.Model.ProductOrderPublishedEvent;
using static Laborator3.OrderedProductsOperations;

namespace Laborator3;

public class OrderProductsWorkflow
{
    public IProductOrderPublishedEvent Execute(OrderProductsCommand command,
                                               Func<ProductCode, bool> checkProductExists,
                                               Func<Quantity, bool> checkProductIsInStock)
    {
        UnvalidatedOrderedProducts unvalidatedOrderedProducts = new(command.InputOrderedProducts);
        IOrderedProducts products = ValidateOrderedProducts(checkProductExists,
                                                            checkProductIsInStock,
                                                            unvalidatedOrderedProducts);
        products = CalculateOrderedProducts(products);
        products = PublishOrderedProducts(products);

        return products.Match(
            whenUnvalidatedOrderedProducts: unvalidatedProducts
                => new ProductOrderPublishedFailedEvent("Unexpected unvalidated state") as IProductOrderPublishedEvent,
            whenInvalidatedOrderedProducts: invalidProducts => new ProductOrderPublishedFailedEvent(invalidProducts.Reason),
            whenValidatedOrderedProducts: validatedProducts => new ProductOrderPublishedFailedEvent("Unexpected validated state"),
            whenCalculatedOrderedProducts: calculatedProducts => new ProductOrderPublishedFailedEvent("Unexpected calculated state"),
            whenPublishedOrderedProducts: publishedProducts
                => new ProductOrderPublishedSucceededEvent(publishedProducts.Csv, publishedProducts.PublishedDate));
    }
}
