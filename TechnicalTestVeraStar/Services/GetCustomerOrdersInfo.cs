using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;
using System.Linq;
using TechnicalTestVeraStar.Models.DrivedModels;
namespace TechnicalTestVeraStar.Services
{
    public class GetCustomerOrdersInfo : IGetCustomerOrdersInfo
    {
        
        public IEnumerable<T> GetCustomerOrderInfo<T>(IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderItem> orderItems)
        {
            IEnumerable<T> result =null;
            try
            {
                var orderInfoResult = from order in orders
                                      join item in orderItems on order.order_id equals item.order_id into ItemsInfo
                                      select new OrderInfo
                                      {
                                          order = order,
                                          orderItems = ItemsInfo.Where(oi => oi.order_id == order.order_id).ToList()
                                      };
                var OrderInfoList = orderInfoResult.ToList();

                var testResult = from customer in customers
                                 join order in orders on customer.customer_id equals order.customer_id into customerOrders
                                 select new CustomerOrderInfo
                                 {
                                     Customer = customer,
                                     Orders = OrderInfoList.Where(oi => oi.order.customer_id == customer.customer_id).ToList()
                                 };

               var finalResult = testResult.ToList();
                return (IEnumerable<T>)finalResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return result;
            }
            }
    }
}
