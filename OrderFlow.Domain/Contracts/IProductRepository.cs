

using OrderFlow.Domain.Entities;

namespace OrderFlow.Domain.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetProductsNeverOrdered();
        List<Product> GetProductsLowStock(int threshold);
        List<Product> GetTopSellingProducts(int count);

        
    }
}
