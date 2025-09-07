using Behavioral;
using Creational;
using Structural;
using File = Structural.File;
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

// #region Builder
// Console.WriteLine("----------Builder---------");
// IBurgerBuilder builder = new BurgerBuilder();
// BurgerDirector director = new BurgerDirector(builder);
// Burger cheeseBurger = director.MakeCheeseBurger();
// Console.WriteLine(cheeseBurger);

// // Custom Build
// Burger burger = builder.AddCheese("Doube Extra Cheese")
//                        .AddMayo("Eggless Mayo")
//                        .AddPatty("Beef")
//                        .Build();
// Console.WriteLine(burger);
// #endregion

// #region Prototype
// Console.WriteLine("----------Prototype---------");
// Enemy flyingEnemy1 = new FlyingEnemy(60, 90, "Fire");
// Enemy flyingEnemy2 = flyingEnemy1.Clone();
// flyingEnemy2.SetHealth(70);

// Enemy armoredEnemy1 = new ArmoredEnemy(90, 50, "Sword");
// Enemy armoredEnemy2 = armoredEnemy1.Clone();
// Console.WriteLine(flyingEnemy1);
// Console.WriteLine(flyingEnemy2);
// Console.WriteLine(armoredEnemy1);
// Console.WriteLine(armoredEnemy2);
// #endregion

// #region Bridge
// Console.WriteLine("----------Bridge---------");
// IRenderer renderer = new RasterRenderer();
// Shape shape = new Circle(renderer, 5);
// shape.Draw();
// renderer = new VectorRenderer();
// shape = new Square(renderer, 5);
// shape.Draw();
// #endregion Bridge

// #region Composite
// Console.WriteLine("----------Composite---------");
// Folder home = new Folder("Home");
// Folder document = new Folder("Documents");
// Folder images = new Folder("Images");

// IFileSystem file1 = new File("resume.pdf", 300);
// IFileSystem file2 = new File("document.csv", 400);

// IFileSystem image1 = new File("lotus.png", 400);

// home.Add(document);
// home.Add(images);

// document.Add(file1);
// document.Add(file2);

// images.Add(image1);

// home.PrintStructure(" ");
// Console.WriteLine("Total size :" + home.GetSize());

// #endregion

// #region decorator
// Console.WriteLine("----------Decorator---------");
// Coffee plain = new SimpleCoffee();
// CoffeeDecorator dec = new MilkDecorator(plain);
// CoffeeDecorator sug = new SugarDecorator(dec);

// Console.WriteLine(sug.GetDetails() + " - " + sug.GetAmount());
// #endregion

// # region Facade
// Console.WriteLine("------------Facade------------");
// var dvd = new DvdPlayer();
// var projector = new Projector();
// var lights = new Light();
// var sound = new Sound();

// HomeTheatreFacade ht = new(lights, dvd, projector, sound);
// ht.WatchMovie("Inception", 100);
// Console.Write("Press any key to end the movie");
// Console.Read();
// ht.EndMovie();
// #endregion

// #region Flyweight
// // Console.WriteLine("------------Flyweight------------");
// CharacterGlyphs cg = new();
// var str = "Hello world";
// var x = 0;
// foreach (var s in str)
// {
//     x += 5;
//     var c = cg.Get(s, 14);
//     c.show(x, 0);
// }
// Console.WriteLine($"Total characters {str.Length} & Total Instance {cg.count}");
// #endregion

// #region Proxy
// Console.WriteLine("------------Proxy------------");
// ImageProxy proxy = new("Image One");
// ImageProxy proxyTwo = new("Image Two");
// ImageProxy proxyThree = new("Image Three");

// proxy.Display();
// proxy.Display(); // displaying from cache (if users closes image and opens again in gallery app)
// #endregion

// #region Iterator
// Console.WriteLine("------------Iterator------------");
// MusicPlayer mp = new MusicPlayer(10);
// mp.Add("Kombe Sura");
// mp.Add("ennavale adi ennavale");
// mp.Add("eehh aatha aathoromaa vaariya");
// mp.Add("channa mereya mereya");
// mp.Add("isn't it lovely");

// MusicPlayerIterator iterator = new(mp);
// while (iterator.hasNext())
// {
//     Console.WriteLine(iterator.next() ?? "No Songs Found");
// }

// VLCPlayer vp = new(10);
// vp.Add("Bad Tamessuuh");
// vp.Add("Vaa Maduraaa Anna Kodi");
// vp.Add("When I m back in chicagoo I feeel eehh anotherrr version off meeee I was innnn it");
// vp.Add("some mistakes get made that's alright thats okay in the end its better for me its the morale of the story huh uh uh uh uh uh");
// vp.Add("when I get older i ll be stronger they ll call me freedom just like a wavin' flag then it goes back oh oh oh oh oh");

// foreach (var song in vp)
// {
//     Console.WriteLine(song ?? "Nooooo");
// }
// #endregion

// #region Observer
// Console.WriteLine("------------Observer------------");
// ISubject ip = new IPhone();
// ISubscriber custOne = new UserOne();
// ip.Subscribe(custOne);

// ip.Launch();

// #endregion

// # region Strategy
// // Console.WriteLine("------------Strategy------------");
// IPaymentStrategy paymentStrategy = new UPI();
// ShoppingCart cart = new(paymentStrategy);
// cart.Checkout();

// cart.SetStrategy(new CreditCard());
// cart.Checkout();
// #endregion

#region Command
Console.WriteLine("------------Command------------");
Behavioral.Light light = new(); // create receiver
ICommand turnOnLight = new LightOnCommand(light); // create command (action encapsulated/wrappe as an object)
Remote remote = new(turnOnLight); // create invoker. remove doesn't know what command it does internally. it just executes/undo.
remote.Execute(); // execute later
#endregion