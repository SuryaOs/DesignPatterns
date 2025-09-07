namespace Behavioral;

#region Command
/*
    it encapsulates a request/action as an object.
        ex. you want to
            turn on light
            save a file
            send a email
    instead of directly calling method light.TurnOn(), file.Save(), email.Send().
    you create an object that knows how to perform these action
        ex. LightOnCommand lc = new(light);
    three keys
        command - the action: turn on the light, bring me the burger
        invoker -  the trigger: remote, waiter (takes the command(order) and passes to receiver(chef, light))
        receiver - the one who does actual work - light, chef
    use when you want to
        parameterize objects by an action to perform. 
            parameterizing remote control - it doesn't care what action it does (tv, light etc...)
            you're parameterizing remote control with diff actions to perform
            you pass in any action, remote control will perform.
        queue requests, schedule operations, or log operations
        support undo/redo functionality
*/
#endregion
public interface ICommand
{
    void Execute();
    void Undo();
}
public class Light // Receiver
{
    public void On()
    {
        Console.WriteLine($"Turning Lights On");
    }
    public void Off()
    {
        Console.WriteLine($"Turning Lights Off");
    }
}
public class LightOnCommand : ICommand // command
{
    private Light light;
    public LightOnCommand(Light light)
    {
        this.light = light;
    }
    public void Execute()
    {
        light.On();
    }
    public void Undo()
    {
        light.Off();
    }
}
public class LightOffCommand : ICommand // command
{
    private Light light;
    public LightOffCommand(Light light)
    {
        this.light = light;
    }
    public void Execute()
    {
        light.Off();
    }
    public void Undo()
    {
        light.On();
    }
}
public class Remote // invoker
{
    private ICommand command;
    private List<ICommand> history = new();
    public Remote(ICommand command)
    {
        this.command = command;
    }
    public void Execute()
    {
        command.Execute();
        history.Add(command);
    }
    public void UndoLastAction()
    {
        if (history.Count > 0)
        {
            var lastAction = history[^1];
            lastAction.Undo();
            history.Remove(lastAction);
        }
        else
        {
            Console.WriteLine("no actions to undo");
        }
    }
}