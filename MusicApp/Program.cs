using Microsoft.Extensions.DependencyInjection;
using MusicApp.Data;
using MusicApp.Services;


ServiceProvider _serviceProvider;
SeedingService _seedingService;

// Create service collection
var services = new ServiceCollection();

services.AddDbContext<ApplicationDbContext>();
services.AddScoped<SeedingService>();

// Build services
_serviceProvider = services.BuildServiceProvider();

// Retrieve the SeedingService
_seedingService = _serviceProvider.GetRequiredService<SeedingService>();

// Seed the database
await _seedingService.SeedDatabase();