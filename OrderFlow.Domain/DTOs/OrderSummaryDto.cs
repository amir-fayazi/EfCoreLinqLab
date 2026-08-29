
namespace OrderFlow.Domain.DTOs
{
    public class OrderSummaryDto
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int ItemsCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
