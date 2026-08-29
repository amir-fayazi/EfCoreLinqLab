

using OrderFlow.Domain.Entities;

namespace OrderFlow.Domain.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetProductsNeverOrdered();
        List<Product> GetProductsLowStock(int threshold);
        List<Product> GetTopSellingProducts(int count);
        List<Product> GetProductsMoreExpensiveThan(decimal price);
        bool HasAnyOutOfStockProduct();
        List<string> GetProductNamesInStock();
        List<Product> GetProductsInPriceRange(decimal minPrice, decimal maxPrice);
        bool HasProductMoreExpensiveThan(decimal price);
        List<string> GetOutOfStockProductNames();
    }
}
