namespace Behavioral;
// when a state changes in an subject, it notifies to all the subscribers object
// similar to subject/observables in angular. realtime youtube subscribers
public interface ISubject // Observable, YouTube
{
    void Subscribe(ISubscriber customer);
    void Unsubscribe(ISubscriber customer);
    void Launch();
}
public interface ISubscriber // Observer, User
{
    void Notify(string message);
}
public class IPhone : ISubject
{
    private HashSet<ISubscriber> subscribers = new();
    public void Launch()
    {
        foreach (var sub in subscribers)
        {
            sub.Notify("IPhone is available");
        }
    }

    public void Subscribe(ISubscriber customer)
    {
        subscribers.Add(customer);
    }

    public void Unsubscribe(ISubscriber customer)
    {
        subscribers.Remove(customer);
    }
}
public class UserOne : ISubscriber
{
    public void Notify(string message)
    {
        Console.WriteLine($"{message} notification alert");
    }
}
public class UserTwo : ISubscriber
{
    public void Notify(string message)
    {
        Console.WriteLine($"{message} notification alert");
    }
}