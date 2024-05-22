using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Services;

ServiceProvider _serviceProvider;

/**
    These are the variables we will use to call
    methods from each of these datatypes (SeedingService,
    DatabaseService, and BasicQueryService)
*/
SeedingService _seedingService;
DatabaseService _dbService;
BasicQueryService _basicQueryService;

// This is the "container" we put the services in which
// we want for dependency injection.
var services = new ServiceCollection();

// Add database to the service
services.AddDbContext<ApplicationDbContext>();

// Add seeding service to the service collection
services.AddScoped<SeedingService>();
services.AddScoped<DatabaseService>();
services.AddScoped<BasicQueryService>();


// Build the service collection
_serviceProvider = services.BuildServiceProvider();

/*
    Retrieve instances of our service out of the
    service collection (after it has been built from
    the line above) for use.
*/
_seedingService = _serviceProvider.GetRequiredService<SeedingService>();
_dbService = _serviceProvider.GetRequiredService<DatabaseService>();
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


// var students = await _dbService.GetAllStudents();

// foreach(var student in students){
//     Console.WriteLine(student.LastName);
//     Console.WriteLine($"Number of courses: {student.Courses.Count}");
//     // foreach(var course in student.Courses){
//     //     Console.WriteLine(course.Name);
//     // }

//     Console.WriteLine("============================");
// }

var courses = await _dbService.GetAllCourses();

foreach(var course in courses) {
    Console.WriteLine(course.Name);
    Console.WriteLine($"InstructorId: {course.InstructorId}");
    Console.WriteLine($"Instructor Name: {course.Instructor.LastName}");

    Console.WriteLine("=========================");
}

