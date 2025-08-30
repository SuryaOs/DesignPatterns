namespace Structural;
// it lets you attach new behaviors to object
// by placing these object inside wrapper object that contains 
// behavior
public interface Coffee
{
    string GetDetails();
    double GetAmount();
}
public class SimpleCoffee : Coffee
{
    public string GetDetails()
    {
        return "SimpleCoffee";
    }
    public double GetAmount()
    {
        return 10.0;
    }
}
public abstract class CoffeeDecorator : Coffee
{
    protected Coffee _coffee;
    public CoffeeDecorator(Coffee coffee)
    {
        _coffee = coffee;
    }
    public virtual string GetDetails()
    {
        return _coffee.GetDetails();
    }
    public virtual double GetAmount()
    {
        return _coffee.GetAmount();
    }
}
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(Coffee coffee) : base(coffee)
    {

    }
    public override string GetDetails()
    {
        return _coffee.GetDetails() + ", Milk";
    }
    public override double GetAmount()
    {
        return 5 + _coffee.GetAmount();
    }
}
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(Coffee coffee) : base(coffee)
    {

    }
    public override string GetDetails()
    {
        return _coffee.GetDetails() + ", Sugar";
    }
    public override double GetAmount()
    {
        return 2 + _coffee.GetAmount();
    }
}