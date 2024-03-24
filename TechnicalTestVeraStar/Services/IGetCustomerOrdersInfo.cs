using System.Globalization;

namespace TechnicalTestVeraStar.Services
{
    public interface IGetCustomerOrdersInfo
    {
        public IEnumerable<T> GetCustomerOrderInfo<T>(IEnumerable<Customer>customers, IEnumerable<Order>orders , IEnumerable<OrderItem>orderItems);
    }
}
