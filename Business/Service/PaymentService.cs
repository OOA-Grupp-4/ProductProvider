using Business.Interfaces;

namespace Business.Service;

public class PaymentService: IPaymentService    
{
    public bool PayWithPayPal(string userId, decimal amount, string paypalAccount)
    {
        
        if (amount > 0 && !string.IsNullOrEmpty(paypalAccount))
        {
            return true; 
        }
        return false; 
    }


}
