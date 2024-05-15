using SchoolSystem.Models;
using SchoolSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Services;

public class BasicQueryService{
    private ApplicationDbContext _context;
		
		// TODO: Use dependency injection to initialize the database context.
    public BasicQueryService(ApplicationDbContext context) {
		_context = context;
    }

    public List<string> GetAllInstructorNames(){ 
	    /*
            SELECT Name
            FROM Instructors;
        */
        return _context.Instructors
                        .Select(instructor => instructor.LastName)
                        .ToList();
    }

    public List<string> GetStudentsInCourse(string courseName){ 
        return _context.Courses
                        .Where(course => course.Name == courseName)
                        // .Select(course => course.Students)
                        .SelectMany(course => course.Students)
                        .Select(student => student.LastName)
                        .ToList();
    }

    public List<string> GetDepartmentsWithCourses(){ 
        return _context.Departments
                        .Where(dept => dept.Courses.Count > 0)
                        .Select(dept => dept.Name)
                        .ToList();

    }

    public string GetDepartmentWithMostCourses(){ 
        // TODO: Implement.

        return null;
    }

    public List<string> GetStudentsEnrolledInMoreThanFiveCourses(){ 
	    // TODO: Implement.

        return null;
    }

    public List<string> GetCoursesByInstructor(string instructorName){ 
	    // TODO: Implement.

        return null;
    }

    public List<string> GetStudentsWithNoCourses(){ 
        // TODO: Implement.

        return null;
    }

    public string GetInstructorWithMostCourses(){
        // TODO: Implement.

        return null;
    }

    /*
        This method groups students by the year they enrolled. 
        After grouping, it then converts the grouped data into a Dictionary. 
        The keys of the dictionary are enrollment years (group.Key), 
        and the values are lists of student names who enrolled in the 
        respective year (group.Select(s => s.Name).ToList()).
    */   
    public Dictionary<int, List<string>> GetStudentsGroupedByEnrollmentYear(){ 
        // TODO: Implement.

        return null;
    }


    /*
        This method groups courses by the department name. After grouping, it 
        then converts the grouped data into a Dictionary. The keys of the 
        dictionary are department names (group.Key), and the values are lists of 
        course names that belong to the respective department 
        (group.Select(c => c.CourseName).ToList()).
    */
    public Dictionary<string, List<string>> GetCoursesGroupedByDepartment(){ 
				// TODO: Implement.

                return null;
    }

    /*
        In this method, we first use SelectMany to flatten the collection of students along with their 
        associated courses into a single collection. Here, we're using an overload of SelectMany that 
        projects each student and course into a new anonymous object.

        Then we group these objects by the course name (sc.course.CourseName), and finally, we construct a 
        dictionary where each key is a course name and each value is a list of last names of the students enrolled in that course. 
        Note that sc is a shorthand for the anonymous object with properties student and course.

    */
    public Dictionary<string, List<string>> GetStudentsGroupedByCourse(){
        // TODO: Implement.

        return null;
    }





}