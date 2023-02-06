// See https://aka.ms/new-console-template for more information
using Ioc;

Console.WriteLine("Hello, World!");

var services = new DIServiceCollections();
//old way 
//services.GenerateSingleton<RandomGuidGenerator>( new RandomGuidGenerator());

// modren way
//services.GenerateSingleton<RandomGuidGenerator>();

//old way 
//services.GenerateTransient<RandomGuidGenerator>( new RandomGuidGenerator());

// modren way
//services.GenerateTransient<RandomGuidGenerator>();
services.GenerateSingleton<IDoSomwthing, DoSometing>();
services.GenerateSingleton<IRandomGuidProvider, RandomGuidProvider>();
services.GenerateSingleton<AppMain>();
var container  = services.GenerateContainer();

var firstService  =container.GetServices<IDoSomwthing>();
var secondtService  =container.GetServices<IDoSomwthing>();
// Console.WriteLine(firstService.Id);
// Console.WriteLine(secondtService.Id);
var secondtService3  =container.GetServices<AppMain>();
firstService.PrintGuid();
secondtService.PrintGuid();
await secondtService3.startTask();