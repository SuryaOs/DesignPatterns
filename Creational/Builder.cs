namespace Creational;

// builds complex object step by step.
public class Burger
{
    public string? Bun;
    public string? Cheese;
    public string? Patty;
    public string? Mayo;
    public bool HasKetchUp;
    public bool HasOnion;
    public bool HasLettuce;
    public override string ToString()
    {
        return $"Your {Bun} {Patty} {Cheese} Burger is loaded with {(HasKetchUp ? "Sauce" : "")}{(HasOnion ? "Onion" : "")}{(HasLettuce ? "Lettuce" : "")} is ready to YEEET";
    }
}
public interface IBurgerBuilder
{
    IBurgerBuilder AddBun(string bun = "Normal");
    IBurgerBuilder AddCheese(string cheese);
    IBurgerBuilder AddPatty(string patty);
    IBurgerBuilder AddMayo(string mayo);
    IBurgerBuilder AddKetchUp();
    IBurgerBuilder AddOnion();
    IBurgerBuilder AddLettuce();
    Burger Build();
}
public class BurgerBuilder : IBurgerBuilder
{
    private Burger _burger = new Burger();

    public IBurgerBuilder AddBun(string bun = "Normal")
    {
        _burger.Bun = bun;
        return this;
    }

    public IBurgerBuilder AddCheese(string cheese)
    {
        _burger.Cheese = cheese;
        return this;
    }

    IBurgerBuilder IBurgerBuilder.AddPatty(string patty)
    {
        _burger.Patty = patty;
        return this;
    }

    IBurgerBuilder IBurgerBuilder.AddMayo(string mayo)
    {
        _burger.Mayo = mayo;
        return this;
    }

    public IBurgerBuilder AddKetchUp()
    {
        _burger.HasKetchUp = true;
        return this;
    }

    public IBurgerBuilder AddOnion()
    {
        _burger.HasOnion = true;
        return this;
    }

    public IBurgerBuilder AddLettuce()
    {
        _burger.HasLettuce = true;
        return this;
    }
    public Burger Build()
    {
        return _burger;
    }
}
public class BurgerDirector
{
    private IBurgerBuilder _burgerBuilder;
    public BurgerDirector(IBurgerBuilder burgerBuilder)
    {
        _burgerBuilder = burgerBuilder;
    }
    public Burger MakeCheeseBurger()
    {
        return _burgerBuilder
        .AddBun("Double Layer")
        .AddPatty("Chicken")
        .AddCheese("Double")
        .AddKetchUp()
        .Build();
    }
}