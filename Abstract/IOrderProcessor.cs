using OnlineShop.Models;

namespace OnlineShop.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingInfo);
    };
}


