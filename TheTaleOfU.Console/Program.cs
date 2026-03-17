using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheTaleOfU;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var services = new ServiceCollection();

services.AddDbContext<TheTaleOfUContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("TheTaleOfUContext")));

services.AddTransient<GameEngine>();

var serviceProvider = services.BuildServiceProvider();

var gameEngine = serviceProvider.GetRequiredService<GameEngine>();
gameEngine.StartGame();
