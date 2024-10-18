using Application.DTOs.Requests;
using Application.DTOs.Responses;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VacancyRequestDTO, Vacancy>(); 
        CreateMap<Vacancy, VacancyResponseDTO>();
        
        CreateMap<ApplicationFormRequestDTO, ApplicationForm>(); 
        CreateMap<ApplicationForm, ApplicationFormResponseDTO>();
        
        CreateMap<TestRequestDTO, Test>(); 
        CreateMap<Test, TestResponseDTO>();
    }
}