using AutoMapper;
using VanillaMvcApp.Models;
using VanillaMvcApp.Models.Dtos;

namespace VanillaMvcApp.Profiles;
public class CourseProfile : Profile {
    public CourseProfile() {
        CreateMap<Course, CourseDto>().ReverseMap();
    }
}