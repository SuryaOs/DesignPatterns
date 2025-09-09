namespace Template;
// it defines skeleton of algorithms in base class
// and allows sub class to override few steps of the algorithms
// without altering the structure.
public abstract class PaymentProcessor
{
    public void Process()
    {
        ValidatePaymentDetails();
        Authenticate();
        ProcessPayment();
        SendReceipt();
    }
    protected abstract void ValidatePaymentDetails();
    protected abstract void Authenticate();
    protected abstract void ProcessPayment();
    public void SendReceipt()
    {
        Console.WriteLine("Sending Receipts...");
    }
}
public class CreditCardPayment : PaymentProcessor
{
    protected override void Authenticate()
    {
        Console.WriteLine("Authenticating Credit Card");
    }

    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing Credit Card Payment");
    }

    protected override void ValidatePaymentDetails()
    {
        Console.WriteLine("Validating Credit Details");
    }
}
public class UPIPayment : PaymentProcessor
{
    protected override void Authenticate()
    {
        Console.WriteLine("Authenticating UPI");
    }

    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing UPI Payment");
    }

    protected override void ValidatePaymentDetails()
    {
        Console.WriteLine("Validating UPI Details");
    }
}