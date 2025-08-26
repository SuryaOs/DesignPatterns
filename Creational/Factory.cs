namespace Creational;
#region SimpleFactory
// subclasses decide what class to create
// breaks open close principle
public interface IVehicle
{
    void Drive();
}
public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving Car");
    }
}
public class Bike : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Riding a Bike");
    }
}
public class SimpleFactory
{
    public IVehicle CreateVehicle(string key)
    {
        switch (key.ToLower())
        {
            case "car": return new Car();
            case "bike": return new Bike();
            default: throw new ArgumentException("Vehicle Not Found");
        }
    }
}
#endregion

#region Factory Method
// creates an interface for creating an object but let's sub class decide which class to instantiate
public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
    public void Drive()
    {
        var _vehicle = CreateVehicle();
        _vehicle.Drive();
    }
}
public class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Car();
}
public class BikeFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Bike();
}
#endregion

#region Abstract Factory
// provides an interface to create family of related object
public interface ITire
{
    void Roll();
}
public interface IEngine
{
    void Start();
}
public class CarTire : ITire {
    public void Roll() { Console.WriteLine("Car tire Rolling"); }
}
public class BikeTire : ITire {
    public void Roll() { Console.WriteLine("Bike tire Rolling"); }
}
public class CarEngine : IEngine {
    public void Start() { Console.WriteLine("Car Engine Starting..."); }
}
public class BikeEngine : IEngine {
    public void Start() { Console.WriteLine("Bike Engine Starting..."); }
}
public abstract class VehiclesFactory
{
    public abstract ITire CreateTire();
    public abstract IEngine CreateEngine();

}
public class CarsFactory : VehiclesFactory
{
    public override ITire CreateTire() => new CarTire();
    public override IEngine CreateEngine() => new CarEngine();
}
public class BikesFactory : VehiclesFactory
{
    public override ITire CreateTire() => new BikeTire();
    public override IEngine CreateEngine() => new BikeEngine();
}
public class Vehicle
{
    private VehiclesFactory _vh;
    public Vehicle(VehiclesFactory vH)
    {
        _vh = vH;
    }
    public void Run()
    {
        var engine = _vh.CreateEngine();
        var tire = _vh.CreateTire();
        engine.Start();
        tire.Roll();
    }
}
#endregion