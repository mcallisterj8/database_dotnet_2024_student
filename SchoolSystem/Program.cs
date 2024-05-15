﻿using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Services;

ServiceProvider _serviceProvider;

SeedingService _seedingService;
BasicQueryService _basicQueryService;

// This is the "container" we put the services in which
// we want for dependency injection.
var services = new ServiceCollection();

// Add database to the service
services.AddDbContext<ApplicationDbContext>();

// Add seeding service to the service collection
services.AddScoped<SeedingService>();
services.AddScoped<BasicQueryService>();


// Build the service collection
_serviceProvider = services.BuildServiceProvider();

_seedingService = _serviceProvider.GetRequiredService<SeedingService>();
_basicQueryService = _serviceProvider.GetRequiredService<BasicQueryService>();

// Seed the database
_seedingService.SeedDatabase();

// Call BasicQuerySerivce methods
var instructorNames = _basicQueryService.GetAllInstructorNames();

// Print out everything in instructorNames
// foreach(string instrName in instructorNames) {
//     Console.WriteLine(instrName);
// }

// Console.WriteLine("=========================================");
// var deptNames = _basicQueryService.GetDepartmentsWithCourses();

// foreach(string dept in deptNames) {
//     Console.WriteLine(dept);
// }
