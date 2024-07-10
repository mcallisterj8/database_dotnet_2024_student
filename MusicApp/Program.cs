using Microsoft.Extensions.DependencyInjection;
using MusicApp.Data;
using MusicApp.Services;


ServiceProvider _serviceProvider;
LinqExamplesService _linqExamplesService;
SeedingService _seedingService;

// Create service collection
var services = new ServiceCollection();

services.AddDbContext<ApplicationDbContext>();
services.AddScoped<LinqExamplesService>();
services.AddScoped<SeedingService>();

// Build services
_serviceProvider = services.BuildServiceProvider();

// Retrieve the SeedingService
// _seedingService = _serviceProvider.GetRequiredService<SeedingService>();

//Seed the database
// await _seedingService.SeedDatabase();

// Retrieve the LinqExamplesSerivce
_linqExamplesService = _serviceProvider.GetRequiredService<LinqExamplesService>();

var result = await _linqExamplesService.GetGenreTrackCounts();

foreach (var elem in result) {
    Console.WriteLine(elem.ToString());
}


