using AutoMapper;
using VanillaMvcApp.Models;
using VanillaMvcApp.Models.Dtos;

namespace VanillaMvcApp.Profiles;
public class StudentProfile : Profile {
    public StudentProfile() {
        CreateMap<Student, StudentDto>().ReverseMap();
    }
}