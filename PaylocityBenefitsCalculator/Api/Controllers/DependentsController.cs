﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EmployeeBenefitCostCalculation.Api.Dtos.Dependent;

using EmployeeBenefitCostCalculation.Api.Models;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitCostCalculation.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int id)
    {
        throw new NotImplementedException();
    }

    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll()
    {
        throw new NotImplementedException();
    }
}
