using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeBenefitCostCalculation.Api.Dtos.Employee;
using EmployeeBenefitCostCalculation.Api.Models;
using EmployeeBenefitCostCalculation.Api.Repositories;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitCostCalculation.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesController(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        var employee = await _employeesRepository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound(new ApiResponse<GetEmployeeDto>
            {
                Success = false,
                Error = "NOT FOUND",
                Message = "Employee not found"
            });
        }

        return new ApiResponse<GetEmployeeDto>
        {
            Data = employee.ToDto(),
            Success = true
        };
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
    {
        var employees = await _employeesRepository.GetAllEmployeesAsync();
        return new ApiResponse<List<GetEmployeeDto>>
        {
            Data = employees.Select(x => x.ToDto()).ToList(),
            Success = true
        };
    }
}
