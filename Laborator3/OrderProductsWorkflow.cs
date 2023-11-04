using Laborator3.Model;
using LanguageExt;
using static Laborator3.Model.OrderedProducts;
using static Laborator3.Model.ProductOrderPublishedEvent;
using static Laborator3.OrderedProductsOperations;

namespace Laborator3;

public class OrderProductsWorkflow
{
    public async Task<IProductOrderPublishedEvent> ExecuteAsync(OrderProductsCommand command,
                                                                Func<ProductCode, TryAsync<bool>> checkProductExists,
                                                                Func<Quantity, TryAsync<bool>> checkProductIsInStock)
    {
        UnvalidatedOrderedProducts unvalidatedOrderedProducts = new(command.InputOrderedProducts);
        IOrderedProducts products = await ValidateOrderedProducts(checkProductExists,
                                                                  checkProductIsInStock,
                                                                  unvalidatedOrderedProducts);
        products = CalculateOrderedProducts(products);
        products = PublishOrderedProducts(products);

        return products.Match(
            whenUnvalidatedOrderedProducts: unvalidatedProducts
                => new ProductOrderPublishedFailedEvent("Unexpected unvalidated state") as IProductOrderPublishedEvent,
            whenInvalidatedOrderedProducts: invalidProducts
                => new ProductOrderPublishedFailedEvent(invalidProducts.Reason),
            whenValidatedOrderedProducts: validatedProducts
                => new ProductOrderPublishedFailedEvent("Unexpected validated state"),
            whenCalculatedOrderedProducts: calculatedProducts
                => new ProductOrderPublishedFailedEvent("Unexpected calculated state"),
            whenPublishedOrderedProducts: publishedProducts
                => new ProductOrderPublishedSucceededEvent(publishedProducts.Csv, publishedProducts.PublishedDate));
    }
}
