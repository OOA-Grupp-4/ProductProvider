namespace Business.Models;

public class Order
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CustomerName { get; set; } = null!;
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }

    public Delivery Delivery { get; private set; } = new Delivery();

  public void UpdateDeliveryInfo(string address, string customerDetails, string date)
    {
        Delivery.Address = address;
        Delivery.CustomerDetails = customerDetails;
        Delivery.Date = date;
    }
    
    public OrderStatus Status { get; set; } = new PendingStatus();
}
