

namespace OrderFlow.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public DateOnly CreateAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public bool IsPaid { get; set; }


        public List<OrderItem> OrderItems { get; set; } = [];
        public Customer Customer { get; set; }
    }
}
