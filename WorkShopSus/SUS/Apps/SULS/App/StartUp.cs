namespace App
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using SUS.MvcFramework;
    using SUS.HTTP;       
    using Services;

    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new SULSContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}