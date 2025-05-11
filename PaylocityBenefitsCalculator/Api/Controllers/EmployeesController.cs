using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeBenefitCostCalculation.Api.Dtos.Employee;
using EmployeeBenefitCostCalculation.Api.Extensions;
using EmployeeBenefitCostCalculation.Api.Models;
using EmployeeBenefitCostCalculation.Api.Repositories;
using EmployeeBenefitCostCalculation.Api.Services;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitCostCalculation.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesRepository _employeesRepository;
    private readonly ICostCalculationService _costCalculationService;

    public EmployeesController(IEmployeesRepository employeesRepository, ICostCalculationService costCalculationService)
    {
        _employeesRepository = employeesRepository;
        _costCalculationService = costCalculationService;
    }

    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> GetEmployee(int id)
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
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAllEmployees()
    {
        var employees = await _employeesRepository.GetAllEmployeesAsync();
        return new ApiResponse<List<GetEmployeeDto>>
        {
            Data = employees.Select(x => x.ToDto()).ToList(),
            Success = true
        };
    }

    [SwaggerOperation(Summary = "Get employee payslip by id")]
    [HttpGet("{id}/payslip")]
    public async Task<ActionResult<ApiResponse<GetEmployeePayslipDto>>> GetEmployeePayslip(int id, [FromQuery] int year, [FromQuery] int payrollNumber)
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

        var payslip = _costCalculationService.CalculateEmployeeCosts(employee, year, payrollNumber);

        return new ApiResponse<GetEmployeePayslipDto>
        {
            Data = payslip.ToDto(),
            Success = true
        };
    }
}
