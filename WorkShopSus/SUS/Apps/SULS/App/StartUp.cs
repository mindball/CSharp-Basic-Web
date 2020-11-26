namespace App
{
    using Data;
    using SUS.MvcFramework;
    using SUS.HTTP;    
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new SULSContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //serviceCollection.Add<IUsersService, UsersService>();
            //serviceCollection.Add<ICardsService, CardsService>();
        }
    }
}