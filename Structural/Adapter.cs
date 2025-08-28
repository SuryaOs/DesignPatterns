namespace Structural;
// lets legacy/third party object to fit the new interface by creating an wrapper class
public interface IPaymentProcessor
{
    void ProcessPayment();
    bool IsPaymentSucessfull();
}
public class InHousePaymentProcessor : IPaymentProcessor
{
    public bool IsPaymentSucessfull()
    {
        return true;
    }

    public void ProcessPayment()
    {
        Console.WriteLine("Payment Done");
    }
}
public class LegacyPaymentProcessor
{
    public bool CheckStatus()
    {
        return true;
    }
    public void ExecuteTransaction()
    {
        Console.WriteLine("Transaction Executing");
    }
}
public class LegacyAdapter : IPaymentProcessor
{
    private LegacyPaymentProcessor _legacyPaymentProcessor = new();
    public bool IsPaymentSucessfull()
    {
        return _legacyPaymentProcessor.CheckStatus();
    }
    public void ProcessPayment()
    {
        _legacyPaymentProcessor.ExecuteTransaction();
    }
}