namespace Behavioral;

// it defines an object that encapsulates how set of objects interacts
public interface IChatRoom
{
    void SendMessage(string message, User sender);
    void RegisterUser(User user);
}
public class ChatRoom : IChatRoom
{
    private List<User> users = new();
    public void RegisterUser(User user)
    {
        users.Add(user);
        user.SetChatRoom(this);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                user.Receive($"{sender.name} says : {message}");
            }
        }
    }
}
public abstract class User
{
    public string name { get; }
    public ChatRoom _chatroom { get; private set; }
    public User(string name)
    {
        this.name = name;
    }
    public void SetChatRoom(ChatRoom chatRoom)
    {
        _chatroom = chatRoom;
    }
    public abstract void Send(string message);
    public abstract void Receive(string message);
}
public class ConcreteUser : User
{
    public ConcreteUser(string name) : base(name)
    {

    }

    public override void Send(string message)
    {
        _chatroom.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{name} Received Message : {message}");
    }
}
