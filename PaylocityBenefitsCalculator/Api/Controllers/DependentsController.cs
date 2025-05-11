using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeBenefitCostCalculation.Api.Dtos.Dependent;

using EmployeeBenefitCostCalculation.Api.Models;
using EmployeeBenefitCostCalculation.Api.Repositories;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitCostCalculation.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    private readonly IDependentsRepository _dependentsRepository;

    public DependentsController(IDependentsRepository dependentsRepository)
    {
        _dependentsRepository = dependentsRepository;
    }

    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int id)
    {
        var dependent = await _dependentsRepository.GetDependentByIdAsync(id);
        if (dependent == null)
        {
            return NotFound(new ApiResponse<GetDependentDto>
            {
                Success = false,
                Error = "NOT FOUND",
                Message = "Dependent not found"
            });
        }

        return new ApiResponse<GetDependentDto>
        {
            Data = dependent.ToDto(),
            Success = true
        };
    }

    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll()
    {
        var dependents = await _dependentsRepository.GetAllDependentsAsync();
        return new ApiResponse<List<GetDependentDto>>
        {
            Data = dependents.Select(x => x.ToDto()).ToList(),
            Success = true
        };
    }
}
