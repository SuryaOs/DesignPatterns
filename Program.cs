using Creational;
// #region Singleton
// Console.WriteLine("----------Singleton---------");
// var logger = Logger.instance;
// logger.Log("Hello World");
// #endregion

// #region Factory
// #region Simple
// Console.WriteLine("----------Factory---------");
// var vehicle = new SimpleFactory();
// var car = vehicle.CreateVehicle("Car");
// car.Drive();
// var bike = vehicle.CreateVehicle("Bike");
// bike.Drive();
// #endregion

// #region Factory
// Console.WriteLine("----------Factory Method---------");
// VehicleFactory cF = new CarFactory();
// cF.Drive();
// cF = new BikeFactory();
// cF.Drive();
// #endregion

// #region Abstract Factory
// Console.WriteLine("----------Abstract Factory---------");
// VehiclesFactory vF = new CarsFactory();
// Vehicle vH = new(vF);
// vH.Run();
// vF = new BikesFactory();
// vH = new(vF);
// vH.Run();
// #endregion
// #endregion

#region Builder
Console.WriteLine("----------Builder---------");
IBurgerBuilder builder = new BurgerBuilder();
BurgerDirector director = new BurgerDirector(builder);
Burger cheeseBurger = director.MakeCheeseBurger();
Console.WriteLine(cheeseBurger);



// Custom Build
Burger burger = builder.AddCheese("Doube Extra Cheese")
                       .AddMayo("Eggless Mayo")
                       .AddPatty("Beef")
                       .Build();
Console.WriteLine(burger);
#endregion