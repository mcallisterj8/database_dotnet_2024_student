using ECommercePlatform.Data;
using ECommercePlatform.Services;
using Microsoft.Extensions.DependencyInjection;


ServiceProvider _serviceProvider;
SeedingService _seedingService;
DatabaseService _databaseService;

// "bucket" to put services in that we want for
// dependency injection
var services = new ServiceCollection();

services.AddDbContext<ApplicationDbContext>();
services.AddScoped<SeedingService>();
services.AddScoped<DatabaseService>();


// Build the service provider
_serviceProvider = services.BuildServiceProvider();

_seedingService = _serviceProvider.GetRequiredService<SeedingService>();
_databaseService = _serviceProvider.GetRequiredService<DatabaseService>();


// seed the database
_seedingService.SeedDatabase();