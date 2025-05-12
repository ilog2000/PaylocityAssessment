using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;

using Xunit;

using Calc = Api.Extensions.CalculationExtensions;

namespace ApiTests.IntegrationTests;

public class EmployeeIntegrationTests : IntegrationTest
{
    public EmployeeIntegrationTests(TestServer factory) : base(factory)
    {
    }

    [Fact]
    public async Task WhenAskedForAllEmployees_ShouldReturnAllEmployees()
    {
        var response = await HttpClient.GetAsync("/api/v1/employees");
        var employees = new List<GetEmployeeDto>
        {
            new()
            {
                Id = 1,
                FirstName = "LeBron",
                LastName = "James",
                Salary = 75420.99m,
                DateOfBirth = new DateTime(1984, 12, 30)
            },
            new()
            {
                Id = 2,
                FirstName = "Ja",
                LastName = "Morant",
                Salary = 92365.22m,
                DateOfBirth = new DateTime(1999, 8, 10),
                Dependents = new List<GetDependentDto>
                {
                    new()
                    {
                        Id = 1,
                        FirstName = "Spouse",
                        LastName = "Morant",
                        Relationship = Relationship.Spouse,
                        DateOfBirth = new DateTime(1998, 3, 3)
                    },
                    new()
                    {
                        Id = 2,
                        FirstName = "Child1",
                        LastName = "Morant",
                        Relationship = Relationship.Child,
                        DateOfBirth = new DateTime(2020, 6, 23)
                    },
                    new()
                    {
                        Id = 3,
                        FirstName = "Child2",
                        LastName = "Morant",
                        Relationship = Relationship.Child,
                        DateOfBirth = new DateTime(2021, 5, 18)
                    }
                }
            },
            new()
            {
                Id = 3,
                FirstName = "Michael",
                LastName = "Jordan",
                Salary = 143211.12m,
                DateOfBirth = new DateTime(1963, 2, 17),
                Dependents = new List<GetDependentDto>
                {
                    new()
                    {
                        Id = 4,
                        FirstName = "DP",
                        LastName = "Jordan",
                        Relationship = Relationship.DomesticPartner,
                        DateOfBirth = new DateTime(1974, 1, 2)
                    }
                }
            }
        };
        await response.ShouldReturn(HttpStatusCode.OK, employees);
    }

    [Fact]
    public async Task WhenAskedForAnEmployee_ShouldReturnCorrectEmployee()
    {
        var response = await HttpClient.GetAsync("/api/v1/employees/1");
        var employee = new GetEmployeeDto
        {
            Id = 1,
            FirstName = "LeBron",
            LastName = "James",
            Salary = 75420.99m,
            DateOfBirth = new DateTime(1984, 12, 30)
        };
        await response.ShouldReturn(HttpStatusCode.OK, employee);
    }
    
    [Fact]
    public async Task WhenAskedForANonexistentEmployee_ShouldReturn404()
    {
        var response = await HttpClient.GetAsync($"/api/v1/employees/{int.MinValue}");
        await response.ShouldReturn(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task WhenAskedForPayslipWithNoDependents_ShouldReturnCorrectPayslip()
    {
        var year = 2025;
        var payrollNumber = 11;
        var response = await HttpClient.GetAsync($"/api/v1/employees/1/payslip?year={year}&payrollNumber={payrollNumber}");
        var payslip = new GetEmployeePayslipDto
        {
            EmployeeId = 1,
            EmployeeName = "James LeBron",
            SalaryPay = Calc.AnnualToPaycheck(75420.99m, Api.Constants.PaychecksPerYear),
            Benefits = Calc.MonthlyToPaycheck(1000m, Api.Constants.PaychecksPerYear),
            PayPeriodStart = new DateTime(2025, 5, 21),
            PayPeriodEnd = new DateTime(2025, 6, 3)
        };  
        await response.ShouldReturn(HttpStatusCode.OK, payslip);
    }

    [Fact]
    public async Task WhenAskedForPayslipWithMultipleDependents_ShouldReturnCorrectPayslip()
    {
        var year = 2025;
        var payrollNumber = 11;
        var response = await HttpClient.GetAsync($"/api/v1/employees/2/payslip?year={year}&payrollNumber={payrollNumber}");
        var payslip = new GetEmployeePayslipDto
        {
            EmployeeId = 2,
            EmployeeName = "Morant Ja",
            SalaryPay = Calc.AnnualToPaycheck(92365.22m, Api.Constants.PaychecksPerYear),
            Benefits = Calc.MonthlyToPaycheck(1000m + 3 * 600m, Api.Constants.PaychecksPerYear) + Calc.AnnualToPaycheck(92365.22m * 0.02m, Api.Constants.PaychecksPerYear),
            PayPeriodStart = new DateTime(2025, 5, 21),
            PayPeriodEnd = new DateTime(2025, 6, 3)
        };  
        await response.ShouldReturn(HttpStatusCode.OK, payslip);
    }

    [Fact]
    public async Task WhenAskedForPayslipWithAgedDependents_ShouldReturnCorrectPayslip()
    {
        var year = 2025;
        var payrollNumber = 11;
        var response = await HttpClient.GetAsync($"/api/v1/employees/3/payslip?year={year}&payrollNumber={payrollNumber}");
        var payslip = new GetEmployeePayslipDto
        {
            EmployeeId = 3,
            EmployeeName = "Jordan Michael",
            SalaryPay = Calc.AnnualToPaycheck(143211.12m, Api.Constants.PaychecksPerYear),
            Benefits = Calc.MonthlyToPaycheck(1000m + 600m + 200m, Api.Constants.PaychecksPerYear) + Calc.AnnualToPaycheck(143211.12m * 0.02m, Api.Constants.PaychecksPerYear),
            PayPeriodStart = new DateTime(2025, 5, 21),
            PayPeriodEnd = new DateTime(2025, 6, 3)
        };  
        await response.ShouldReturn(HttpStatusCode.OK, payslip);
    }
}

