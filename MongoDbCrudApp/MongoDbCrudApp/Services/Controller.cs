using MongoDbCrudApp.BusinessLayer;
using MongoDbCrudApp.UserInterfaceLayer;

namespace MongoDbCrudApp.Services
{

    class Controller : IController
    {
        private readonly IPlanetService _planetService;
        private readonly IUserInterface _userInterface;

        public Controller(IPlanetService planetService, IUserInterface userInterface)
        {
            _planetService = planetService;
            _userInterface = userInterface;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                var choice = _userInterface.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        var planet = _userInterface.GetItem();
                        await _planetService.CreateAsync(planet);
                        break;
                    case 2:
                        var name = _userInterface.GetName();
                        var result = await _planetService.ReadAsync(name);
                        _userInterface.ShowItem(result);
                        break;
                    case 3:
                        var id = _userInterface.GetId();
                        var updatePlanet = _userInterface.GetItem();
                        await _planetService.UpdateAsync(id, updatePlanet);
                        break;
                    case 4:
                        var itemToDelete = _userInterface.GetName();
                        await _planetService.DeleteAsync(itemToDelete);
                        break;
                    case 5:
                        return;
                }
            }
        }
    }

}


