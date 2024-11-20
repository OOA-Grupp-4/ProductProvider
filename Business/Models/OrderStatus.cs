namespace Business.Models;

public abstract class OrderStatus
{
    public abstract string Status { get; }
}

public class PendingStatus : OrderStatus
{
    public override string Status => "Pending";
}

public class ShippedStatus : OrderStatus
{
    public override string Status => "Shipped";
}

public class DeliveredStatus : OrderStatus
{
    public override string Status => "Delivered";
}
