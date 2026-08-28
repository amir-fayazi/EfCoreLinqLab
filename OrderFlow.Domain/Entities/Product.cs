

namespace OrderFlow.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Stock { get; set; }

        public List<OrderItems> OrderItems { get; set; } = [];
    }
}
