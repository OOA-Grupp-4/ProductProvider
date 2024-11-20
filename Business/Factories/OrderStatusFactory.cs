using Business.Models;

namespace Business.Factories;

public static class OrderStatusFactory
{
    public static OrderStatus Create(string status)
    {
        return status switch
        {
            "Pending" => new PendingStatus(),
            "Shipped" => new ShippedStatus(),
            "Delivered" => new DeliveredStatus(),
            _ => throw new Exception("Unknown order status.")
        };
    }
}
