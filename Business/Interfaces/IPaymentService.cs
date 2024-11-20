namespace Business.Interfaces;

public interface IPaymentService
{
    public bool PayWithPayPal(string userID, decimal amount, string paypalAccount);
}
    