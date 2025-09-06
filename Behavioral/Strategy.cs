namespace Behavioral;
// it lets us to switch implementation/ choose strategy at run time
public interface IPaymentStrategy
{
    void Pay();
}
public class UPI : IPaymentStrategy
{
    public void Pay()
    {
        Console.WriteLine("pay using upi");
    }
}
public class CreditCard : IPaymentStrategy
{
    public void Pay()
    {
        Console.WriteLine("pay using credit card");
    }
}
public class ShoppingCart
{
    private IPaymentStrategy _paymentStrategy;
    public ShoppingCart(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }
    public void SetStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
    }
    public void Checkout()
    {
        _paymentStrategy.Pay();
    }
}
