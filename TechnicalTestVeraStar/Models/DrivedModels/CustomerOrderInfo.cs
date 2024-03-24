namespace TechnicalTestVeraStar.Models.DrivedModels
{
    public class CustomerOrderInfo
    {
        public Customer Customer { get; set; }
        public List<OrderInfo>? Orders { get; set; }
    }
}
