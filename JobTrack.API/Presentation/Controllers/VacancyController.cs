using System.Net;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Services;
using AutoMapper;
using Domain.Apis;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("jobTrack/[controller]")]
public class VacancyController : ControllerBase
{
    private readonly IVacancyService _vacancyService;
    private readonly IMapper _mapper;

    public VacancyController(IVacancyService vacancyService,IMapper mapper)
    {
        _mapper = mapper;
        _vacancyService = vacancyService;
    }

    [HttpPost("Create")]

    public ActionResult<ApiResponse<VacancyResponseDTO>> CreateVacancy(ApiRequest<VacancyRequestDTO> apiRequest)
    {
        try
        {
            Vacancy vacancyModel = _mapper.Map<Vacancy>(apiRequest.Data);
            _vacancyService.Create(vacancyModel);
            
            return new ApiResponse<VacancyResponseDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Message =  "Vacancy successfully created!",
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<VacancyResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
    
    
    [HttpGet("Get")]
    public ActionResult<ApiResponse<VacancyResponseDTO>> GetVacancy(Guid id)
    {
        try
        {
            var result = _vacancyService.Get(id);

            var resultDTO = _mapper.Map<VacancyResponseDTO>(result);
            
            return new ApiResponse<VacancyResponseDTO>
            {
                Data = resultDTO,
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }
        
        catch (Exception ex)
        {
            return new ApiResponse<VacancyResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
    
    
    [HttpGet("GetAll")]
    public ActionResult<ApiResponse<List<VacancyResponseDTO>>> GetVacancies()
    {
        try
        {
            var result = _vacancyService.GetAll();

            var resultDTO = _mapper.Map<List<VacancyResponseDTO>>(result);
            
            return new ApiResponse<List<VacancyResponseDTO>>
            {
                Data = resultDTO,
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }
        
        catch (Exception ex)
        {
            return new ApiResponse<List<VacancyResponseDTO>>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
    
    
    [HttpDelete("Delete")]
    public ActionResult<ApiResponse<string>> DeleteVacancy(Guid id)
    {
        try
        {
            _vacancyService.Delete(id);

            return new ApiResponse<string>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }
        
        catch (Exception ex)
        {
            return new ApiResponse<string>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
    
    [HttpPut("Update")]
    public ActionResult<ApiResponse<VacancyResponseDTO>> UpdateVacancy(Guid id,ApiRequest<VacancyRequestDTO> apiRequest)
    {
        try
        {
            Vacancy vacancy = _mapper.Map<Vacancy>(apiRequest.Data);
            vacancy.Id = id;
            _vacancyService.Update(vacancy);
            
            return new ApiResponse<VacancyResponseDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }
        
        catch (Exception ex)
        {
            return new ApiResponse<VacancyResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
    
}