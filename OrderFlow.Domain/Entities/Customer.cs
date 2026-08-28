

namespace OrderFlow.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }


        public List<Order> Orders { get; set; } = [];
    }
}
