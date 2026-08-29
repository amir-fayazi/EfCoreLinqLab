

using OrderFlow.Domain.DTOs;
using OrderFlow.Domain.Entities;

namespace OrderFlow.Domain.Contracts
{
    public interface IOrderRepository
    {
        List<Order> GetUnpaidOrders();
        List<Order> GetOrdersByCustomerId(int customerId);
        List<OrderSummaryDto> GetOrderSummaries();
        List<Order> GetOrdersWithMoreThanItems(int itemCount);
        bool HasUnpaidOrder(int customerId);
        decimal GetTotalRevenue();
        decimal GetRevenueByOrderId(int orderId);
    }
}
