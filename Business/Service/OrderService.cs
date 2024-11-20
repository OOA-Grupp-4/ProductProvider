using Business.Factories;
using Business.Models;

namespace Business.Service
{
    public class OrderService
    {
        private readonly List<Order> _orders = [];

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public Order GetOrderDetails(string orderId)
        {
            if (!string.IsNullOrEmpty(orderId))
            {
                return _orders.FirstOrDefault(order => order.Id == orderId)!;
            }

            return null!;
        }

        public bool UpdateOrderStatus(string orderId, string newStatus)
        {
            var order = _orders.FirstOrDefault(order => order.Id == orderId);
            if (order != null)
            {
                order.Status = OrderStatusFactory.Create(newStatus);
                return true;
            }
            return false;
            
        }

        public List<Order> GetOrders() =>_orders;

        public bool UpdateOrderDelivery(string orderId, string address, string customerDetails, string date)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                order.UpdateDeliveryInfo(address, customerDetails, date);
                return true;    
            }

            return false;
        }
    }
}
