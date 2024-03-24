namespace TechnicalTestVeraStar.Models.DrivedModels
{
    public class OrderInfo
    {
        public Order? order { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }
}
