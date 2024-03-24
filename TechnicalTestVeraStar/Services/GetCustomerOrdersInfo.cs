using System.Globalization;
using System.Linq;
using TechnicalTestVeraStar.Models.DrivedModels;
namespace TechnicalTestVeraStar.Services
{
    public class GetCustomerOrdersInfo : IGetCustomerOrdersInfo
    {
        
        public IEnumerable<T> GetCustomerOrderInfo<T>(IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderItem> orderItems)
        {
            //   var result = customers.GroupJoin(
            // orders,
            // customer => customer.customer_id,
            // order => order.customer_id,
            // (customer, orderGroup) => new CustomerOrderInfo
            // {
            //     Customer = customer,
            //     Orders = orderGroup.GroupJoin(
            //         orderItems,
            //         order => order.order_id,
            //         orderItem => orderItem.order_id,
            //         (order, orderItemGroup) => new OrderInfo
            //         {
            //             order = order,
            //             orderItems = orderItemGroup.ToList()
            //         }
            //     ).ToList()
            // }
            //).ToList();
            var DumpOrderItems = orderItems;

            //var testResult = from customer in customers
            //                 join order in orders on customer.customer_id equals order.customer_id into customerOrders
            //                 select new CustomerOrderInfo
            //                 {
            //                     Customer = customer,
            //                     Orders = customerOrders.Select(co => new OrderInfo
            //                     {
            //                         order = co,
            //                         orderItems = orderItems.Where(oi => oi.order_id == co.order_id).ToList()
            //                     }).ToList()
            //                 };

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

            //return result;

            //var testResult = customers.Select(customer => new CustomerOrderInfo
            //{
            //    Customer = customer,
            //    Orders = orders.Where(order => order.customer_id == customer.customer_id)
            //                  .Select(order => new OrderInfo
            //                  {
            //                      order = order,
            //                      orderItems = orderItems.Where(item => item.order_id == order.order_id).ToList()
            //                  })
            //                  .ToList()
            //}).ToList();
            var result = testResult.ToList();
            return (IEnumerable<T>)result;
        }
    }
}
