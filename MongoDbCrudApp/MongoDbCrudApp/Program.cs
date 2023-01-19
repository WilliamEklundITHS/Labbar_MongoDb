using MongoDbCrudApp.BusinessLayer;
using MongoDbCrudApp.Services;
using MongoDbCrudApp.UserInterfaceLayer;
IPlanetService planetService = new PlanetService();
IUserInterface userInterface = new UserInterface();
IController controller = new Controller(planetService, userInterface);
await controller.RunAsync();