using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using TechnicalTestVeraStar.Models.DrivedModels;
using TechnicalTestVeraStar.Services;
using System.Collections;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly IDataService _dataService;
    IWebHostEnvironment WebHostEnvironment;
    private readonly IGetCustomerOrdersInfo _getcustomerOrderInfo;
    private readonly IDiscount _discount;

    public DataController(IDataService dataService,IDiscount discount, IWebHostEnvironment webHostEnvironment, IGetCustomerOrdersInfo getCustomerOrdersInfo)
    {
        _dataService = dataService;
        WebHostEnvironment = webHostEnvironment;
        _getcustomerOrderInfo = getCustomerOrdersInfo;
        _discount = discount;
    }

    [HttpGet("customerOrdersInfo")]
    public ActionResult<IEnumerable<CustomerOrderInfo>> GetCustomersOrderInfo()
    {
        var serverPath = WebHostEnvironment.ContentRootPath + "\\MyAppData\\csv\\Customers.csv";
        var customers = _dataService.ReadCSV<Customer>(serverPath);

        serverPath = WebHostEnvironment.ContentRootPath + "\\MyAppData\\csv\\Orders.csv";
        var orders = _dataService.ReadCSV<Order>(serverPath);

        serverPath = WebHostEnvironment.ContentRootPath + "\\MyAppData\\csv\\OrderItems.csv";
        var orderItems = _dataService.ReadCSV<OrderItem>(serverPath);
        var result = _getcustomerOrderInfo.GetCustomerOrderInfo<CustomerOrderInfo>(customers, orders, orderItems);
        return Ok(result);
    }
    [HttpPost("applyDiscount")]
   public ActionResult<IEnumerator<CustomerOrderInfo>> ApplyDiscount([FromBody]IEnumerable<CustomerOrderInfo> stateCustomerOrderInfo,int percentage) 
    {
        double discount = Convert.ToDouble(percentage);
        var result = _discount.ApplyDiscount(stateCustomerOrderInfo, discount) ;
        return Ok(result);
    }

    [HttpGet("customers")]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        var serverPath = WebHostEnvironment.ContentRootPath + "\\MyAppData\\csv\\Customers.csv";
        var customers = _dataService.ReadCSV<Customer>(serverPath);
        return Ok(customers);
    }



    [HttpGet("orders")]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        var serverPath = WebHostEnvironment.ContentRootPath + "\\MyAppData\\csv\\Orders.csv";
        var orders = _dataService.ReadCSV<Order>(serverPath);
        return Ok(orders);
    }

    [HttpGet("orderItems")]
    public ActionResult<IEnumerable<OrderItem>> GetOrderItems()
    {
        var serverPath = WebHostEnvironment.ContentRootPath + "\\MyAppData\\csv\\OrderItem.csv";
        var orderItems = _dataService.ReadCSV<OrderItem>(serverPath);
        return Ok(orderItems);
    }
}