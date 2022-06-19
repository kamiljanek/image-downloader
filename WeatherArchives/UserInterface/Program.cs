using Flymet;
using Microsoft.Extensions.DependencyInjection;

namespace UserInterface
{
    public class Program
    {

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var menu = ServiceProvider.GetService<IMenu>();
            menu.UserInterface();
        }
        public static ServiceProvider ServiceProvider { get; private set; }
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IMenu, Menu>()
                .AddSingleton<IFileOperation, FileOperation>()
                .AddSingleton<IDisplay, Display>();
        }
    }
}

