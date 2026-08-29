using OrderFlow.Domain.Contracts;
using OrderFlow.Domain.Entities;
using OrderFlow.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Infrustructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Product> GetProductsLowStock(int threshold)
        {
            return _context.Products.Where(x => x.Stock < threshold).ToList();
        }

        public List<Product> GetProductsMoreExpensiveThan(decimal price)
        {
            return [.. _context.Products.Where(x => x.Price > price)];
        }

        public List<Product> GetProductsNeverOrdered()
        {
           return _context.Products.Where(x => !x.OrderItems.Any()).ToList();
        }

        public List<Product> GetTopSellingProducts(int count)
        {
           return _context.OrderItems.GroupBy(x => x.Product)
                .Select(group => new
                {
                    Product = group.Key,
                    TotalQuantity = group.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(count)
                .Select(x => x.Product)
                .ToList();
        }

        public bool HasAnyOutOfStockProduct()
        {
            return _context.Products.Any(x => x.Stock == 0);
        }
        public List<string> GetProductNamesInStock()
        {
            return [.._context.Products
                .Where(x => x.Stock > 0)
                .Select(x => x.Name)];
        }
    }
}
