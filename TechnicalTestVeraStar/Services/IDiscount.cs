using TechnicalTestVeraStar.Models.DrivedModels;

namespace TechnicalTestVeraStar.Services
{
    public interface IDiscount
    {
        public IEnumerable<CustomerOrderInfo> ApplyDiscount(IEnumerable<CustomerOrderInfo> info, double discount);
    }
}
