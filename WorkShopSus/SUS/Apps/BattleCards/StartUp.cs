using BattleCards.Data;
using BattleCards.Services;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace BattleCards
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            //routeTable.Add(new Route("/", HttpMethod.Get, new HomeController().Index));

            //routeTable.Add(new Route("/favicon.ico", HttpMethod.Get, new StaticFilesController().Favicon));
            //routeTable.Add(new Route("/css/custom.css", HttpMethod.Get, new StaticFilesController().CustomCss));
            //routeTable.Add(new Route("/css/bootstrap.min.css", HttpMethod.Get, new StaticFilesController().BootstrapCss));
            //routeTable.Add(new Route("/js/bootstrap.bundle.min.js", HttpMethod.Get, new StaticFilesController().BootstrapJs));
            //routeTable.Add(new Route("/js/custom.js", HttpMethod.Get, new StaticFilesController().CustomJs));

            //routeTable.Add(new Route("/users/login", HttpMethod.Get, new UsersControllerController().Login));
            //routeTable.Add(new Route("/users/register", HttpMethod.Get, new UsersControllerController().Register));
            //routeTable.Add(new Route("/users/login", HttpMethod.Post, new UsersControllerController().DoLogin));

            //routeTable.Add(new Route("/cards/all", HttpMethod.Get, new CardsController().All));
            //routeTable.Add(new Route("/cards/add", HttpMethod.Get, new CardsController().Add));
            //routeTable.Add(new Route("/cards/Collection", HttpMethod.Get, new CardsController().Collection));
            new BattleCardDbContext().Database.Migrate();
        }

        public void ConfigureServices()
        {
            
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
            
        }
    }
}
