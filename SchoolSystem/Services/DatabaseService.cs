using SchoolSystem.Models;
using SchoolSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Services;

public class DatabaseService {
    private readonly ApplicationDbContext _context;

    // TODO: Use dependency injection to initialize the database context.
    public DatabaseService(ApplicationDbContext context) {
        _context = context;
    }

    // Example: Get all students
    public async Task<List<Student>> GetAllStudents() {
        // select * from students;
        // var students = await _context.Students.ToListAsync();

        // return students;

        return await _context.Students
                        .Include(student => student.Courses)
                        .ToListAsync();
    }

    public async Task<ICollection<Course>> GetAllCourses() {
        return await _context.Courses
                        .Include(course => course.Instructor)
                        .ToListAsync();
    }

    public async Task<List<Student>> GetAllStudentsWithCourses() {
        return await _context.Students
                        .Include(student => student.Courses)
                        .ToListAsync();
    }

    public async Task<List<Course>> GetAllCoursesWithStudents() {
        return await _context.Courses
                        .Include(course => course.Students)                        
                        .ToListAsync();
    }

    // Example: Get student by ID, with their courses
    public async Task<Student?> GetStudentById(int id) {
        // TODO: Retrieve a student by their ID and include their related courses, then return the student.
        throw new NotImplementedException();
    }

    public async Task<Student?> GetStudentByIdTest(int id) {
        // TODO: Retrieve a student by their ID without including their related courses, then return the student.
        throw new NotImplementedException();
    }

    // Example: Add a new student
    public async Task AddStudent(Student student) {
        // TODO: Add the given student to the database and save changes.
        throw new NotImplementedException();
    }

    // Example: Update a student
    public async Task<Student?> UpdateStudent(Student studentDetails) {
        // TODO: Retrieve the student by their ID, update their details, and save changes.
        throw new NotImplementedException();
    }

    public async Task<Student?> UpdateStudentName(int studentId, string newFirstName, string newLastName) {
        // TODO: Retrieve the student by their ID, update their first and last name, and save changes.
        throw new NotImplementedException();
    }

    public async Task EnrollStudentInCourse(int studentId, int courseId) {
        // TODO: Retrieve the student and course by their IDs, enroll the student in the course, and save changes.
        throw new NotImplementedException();
    }

    public async Task EnrollStudentInCourseAsync(int studentId, int courseId) {
        // TODO: Retrieve the student and course by their IDs, enroll the student in the course, and save changes.
        throw new NotImplementedException();
    }

    // Example: Delete a student
    public async Task DeleteStudent(int id) {
        // TODO: Retrieve the student by their ID, remove them from the database, and save changes.
        throw new NotImplementedException();
    }

    // Example: Add multiple new students using AddRangeAsync
    public async Task AddMultipleStudentsAsync(IEnumerable<Student> students) {
        // TODO: Add the given list of students to the database using AddRangeAsync and save changes.
        throw new NotImplementedException();
    }
}
