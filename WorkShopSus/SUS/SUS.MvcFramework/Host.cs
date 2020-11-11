using SUS.HTTP;
using SUS.MvcFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port)
        {
            List<Route> routeTable = new List<Route>();
            AutoRegisterRoutes(application, routeTable);

            application.ConfigureServices();
            application.Configure(routeTable);

            IHttpServer server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }

        private static void AutoRegisterRoutes(IMvcApplication application, List<Route> routeTable)
        {
            var controllers = application.GetType()
                .Assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract
                        && typeof(Controller).IsAssignableFrom(type));

            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods(
                    BindingFlags.DeclaredOnly
                    | BindingFlags.Public
                    | BindingFlags.Instance)
                    .Where(method => !method.IsSpecialName && method.DeclaringType == controller);

                foreach (var action in actions)
                {
                    var actionName = controller.Name.Replace("Controller", string.Empty);
                    string urlPath = $"/{actionName}/{action.Name}";

                    var attribute = (BaseHttpAttribute)action.GetCustomAttributes(typeof(BaseHttpAttribute)).FirstOrDefault(); ;

                    var httpMethod = HttpMethod.Get;
                    
                    if (attribute != null && attribute.Method == HttpMethod.Post)
                    {
                        httpMethod = HttpMethod.Post;
                    }

                    if (attribute?.Url != null)
                    {
                        urlPath = attribute.Url;
                    }

                    if (attribute?.ActionName != null)
                    {
                        urlPath = $"/{actionName}/{attribute.ActionName}";
                    }

                    routeTable.Add(new Route(urlPath, httpMethod, request =>
                    {
                        var controllerInstance = Activator.CreateInstance(controller);
                        var response = action.Invoke(controllerInstance, new[] { request }) as HttpResponse;
                        return response;
                    }));

                    Console.WriteLine(httpMethod + " " + urlPath);
                }
            }
        }
    }
}
