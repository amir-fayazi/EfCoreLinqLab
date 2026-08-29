using OrderFlow.Domain.Contracts;
using OrderFlow.Domain.DTOs;
using OrderFlow.Domain.Entities;
using OrderFlow.Infrustructure.Data;


namespace OrderFlow.Infrustructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return [.. _context.Orders.Where(x => x.CustomerId == customerId)];
        }

        public List<OrderSummaryDto> GetOrderSummaries()
        {
            return [.. _context.Orders
                .Select(x => new OrderSummaryDto
                {
                    OrderId = x.Id,
                    CustomerName = x.Customer.Fullname,
                    ItemsCount = x.OrderItems.Count,
                    TotalPrice = x.OrderItems.Sum(item => item.Quantity * item.UnitPrice)
                })];
        }

        public List<Order> GetUnpaidOrders()
        {
            return [.. _context.Orders.Where(x => !x.IsPaid)];
        }

    }
}
