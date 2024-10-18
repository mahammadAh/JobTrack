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
public class TestController : ControllerBase
{
    private readonly ITestService _testService;
    private readonly IMapper _mapper;

    public TestController(ITestService testService, IMapper mapper)
    {
        _mapper = mapper;
        _testService = testService;
    }

    [HttpPost("Create")]
    public ActionResult<ApiResponse<TestResponseDTO>> CreateVacancy(ApiRequest<TestRequestDTO> apiRequest)
    {
        try
        {
            Test testModel = _mapper.Map<Test>(apiRequest.Data);
            _testService.Create(testModel);

            return new ApiResponse<TestResponseDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Test successfully created!",
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<TestResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }


    [HttpGet("Get")]
    public ActionResult<ApiResponse<TestResponseDTO>> GetTest(Guid id)
    {
        try
        {
            var result = _testService.Get(id);

            var resultDTO = _mapper.Map<TestResponseDTO>(result);

            return new ApiResponse<TestResponseDTO>
            {
                Data = resultDTO,
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }

        catch (Exception ex)
        {
            return new ApiResponse<TestResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }


    [HttpGet("GetAll")]
    public ActionResult<ApiResponse<List<TestResponseDTO>>> GetTests()
    {
        try
        {
            var result = _testService.GetAll();

            var resultDTO = _mapper.Map<List<TestResponseDTO>>(result);

            return new ApiResponse<List<TestResponseDTO>>
            {
                Data = resultDTO,
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }

        catch (Exception ex)
        {
            return new ApiResponse<List<TestResponseDTO>>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }


    [HttpDelete("Delete")]
    public ActionResult<ApiResponse<TestResponseDTO>> DeleteTest(Guid id)
    {
        try
        {
            _testService.Delete(id);

            return new ApiResponse<TestResponseDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }

        catch (Exception ex)
        {
            return new ApiResponse<TestResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }

    [HttpPut("Update")]
    public ActionResult<ApiResponse<TestResponseDTO>> UpdateVacancy(Guid id, ApiRequest<TestResponseDTO> apiRequest)
    {
        try
        {
            Test test = _mapper.Map<Test>(apiRequest.Data);
            test.Id = id;
            _testService.Update(test);

            return new ApiResponse<TestResponseDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }

        catch (Exception ex)
        {
            return new ApiResponse<TestResponseDTO>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Success = false
            };
        }
    }
}
