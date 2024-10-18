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
public class ApplicationFormController : ControllerBase
{
    
    private readonly IApplicationFormService _applicationFormService;
    private readonly IMapper _mapper;

    public ApplicationFormController(IApplicationFormService applicationFormService,IMapper mapper)
    {
        _mapper = mapper;
        _applicationFormService = applicationFormService;
    }

    [HttpPost("Create")]

    public ActionResult<ApiResponse<ApplicationFormResponseDTO>> CreateApplicationForm(ApiRequest<ApplicationFormRequestDTO> apiRequest)
    {
        try
        {
            ApplicationForm applicationFormModel = _mapper.Map<ApplicationForm>(apiRequest.Data);
            _applicationFormService.Create(applicationFormModel);
            
            return new ApiResponse<ApplicationFormResponseDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Message =  "Application Form successfully created!",
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<ApplicationFormResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
    
    
    [HttpGet("Get")]
    public ActionResult<ApiResponse<ApplicationFormResponseDTO>> GetApplicationForm(Guid id)
    {
        try
        {
            var result = _applicationFormService.Get(id);

            var resultDTO = _mapper.Map<ApplicationFormResponseDTO>(result);
            
            return new ApiResponse<ApplicationFormResponseDTO>
            {
                Data = resultDTO,
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }
        
        catch (Exception ex)
        {
            return new ApiResponse<ApplicationFormResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
    
    
    [HttpGet("GetAll")]
    public ActionResult<ApiResponse<List<ApplicationFormResponseDTO>>> GetApplicationForms()
    {
        try
        {
            var result = _applicationFormService.GetAll();

            var resultDTO = _mapper.Map<List<ApplicationFormResponseDTO>>(result);
            
            return new ApiResponse<List<ApplicationFormResponseDTO>>
            {
                Data = resultDTO,
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }
        
        catch (Exception ex)
        {
            return new ApiResponse<List<ApplicationFormResponseDTO>>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
    
}