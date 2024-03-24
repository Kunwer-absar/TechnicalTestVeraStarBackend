using TechnicalTestVeraStar.Models.DrivedModels;

namespace TechnicalTestVeraStar.Services
{
    public class Discount : IDiscount
    {
        public IEnumerable<CustomerOrderInfo> ApplyDiscount(IEnumerable<CustomerOrderInfo> info, double discount)
        {
            double discountPercentage = discount / 100;
            foreach (var customerOrderInfoItem in info)
            {
                if (customerOrderInfoItem.Orders != null)
                {
                    foreach (var orderInfo in customerOrderInfoItem.Orders)
                    {
                        if (orderInfo.orderItems != null)
                        {
                            foreach (var orderItem in orderInfo.orderItems)
                            {
                                // Apply the discount to the list_price of each orderItem
                                orderItem.list_price -= orderItem.list_price * discountPercentage;
                            }
                        }
                    }
                }
            }
            return info;
        }
    }
}
