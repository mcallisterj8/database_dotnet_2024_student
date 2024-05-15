using SchoolSystem.Data;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Services {
    public class SeedingService {
        private readonly ApplicationDbContext _context;

        public SeedingService(ApplicationDbContext context) {
            _context = context;
        }

        public void CreateInstructor(string firstName, string lastName, DateTime joiningDate) {
            var instructor = new Instructor {
                FirstName = firstName,
                LastName = lastName,
                JoiningDate = joiningDate
            };
            _context.Instructors.Add(instructor);
        }

        public void CreateStudent(string firstName, string lastName, DateTime joiningDate) {
            var student = new Student {
                FirstName = firstName,
                LastName = lastName,
                JoiningDate = joiningDate
            };
            _context.Students.Add(student);
        }

        public void CreateDepartment(string deptName) {
            var department = new Department {
                Name = deptName
            };
            _context.Departments.Add(department);
        }

        public void CreateCourse(string name, int instructorId, int departmentId) {
            var course = new Course {
                Name = name,
                InstructorId = instructorId,
                DepartmentId = departmentId
            };
            _context.Courses.Add(course);
        }

        public void AddStudentToCourse(int studentId, int courseId) {
            var student = _context.Students.Find(studentId);
            var course = _context.Courses.Find(courseId);
            if (student != null && course != null) {
                course.Students.Add(student);
            }
        }

        public void SeedDatabase() {
            if (_context.Instructors.Any() || _context.Students.Any() || _context.Departments.Any() || _context.Courses.Any()) {
                return; // Database has already been seeded
            }

            // Create Departments
            CreateDepartment("Computer Science");
            CreateDepartment("Mathematics");
            CreateDepartment("Physics");
            _context.SaveChanges();

            // Create Instructors
            CreateInstructor("John", "Doe", new DateTime(2010, 5, 1));
            CreateInstructor("Jane", "Smith", new DateTime(2012, 7, 23));
            CreateInstructor("Alan", "Turing", new DateTime(2015, 3, 14));
            _context.SaveChanges();

            // Get Department IDs
            var csDept = _context.Departments.First(d => d.Name == "Computer Science").Id;
            var mathDept = _context.Departments.First(d => d.Name == "Mathematics").Id;
            var physicsDept = _context.Departments.First(d => d.Name == "Physics").Id;

            // Get Instructor IDs
            var instructorJohn = _context.Instructors.First(i => i.LastName == "Doe").Id;
            var instructorJane = _context.Instructors.First(i => i.LastName == "Smith").Id;
            var instructorAlan = _context.Instructors.First(i => i.LastName == "Turing").Id;

            // Create more courses with varying instructors and departments
            CreateCourse("Data Structures", instructorJohn, csDept);
            CreateCourse("Computer Networks", instructorJohn, csDept);
            CreateCourse("Operating Systems", instructorAlan, csDept);
            CreateCourse("Linear Algebra", instructorJane, mathDept);
            CreateCourse("Statistics", instructorJane, mathDept);
            CreateCourse("Calculus", instructorJane, mathDept);
            CreateCourse("Particle Physics", instructorAlan, physicsDept);
            CreateCourse("Quantum Mechanics", instructorAlan, physicsDept);
            _context.SaveChanges();

            // Create more students
            CreateStudent("Eve", "Larson", new DateTime(2019, 9, 1));
            CreateStudent("Dave", "Lee", new DateTime(2019, 9, 1));
            CreateStudent("Gina", "Wong", new DateTime(2019, 9, 1));
            _context.SaveChanges();

            // Enroll students in various courses
            var allCourses = _context.Courses.ToList();
            var allStudents = _context.Students.ToList();

            // Randomly enroll students in 3 to 7 courses
            Random rng = new Random();
            foreach (var student in allStudents) {
                var shuffledCourses = allCourses.OrderBy(x => rng.Next()).Take(rng.Next(3, 8)).ToList();
                foreach (var course in shuffledCourses) {
                    AddStudentToCourse(student.Id, course.Id);
                }
            }
            _context.SaveChanges();
        }
    }
}
 