using EmployeeBenefitCostCalculation.Api.Dtos.Employee;
using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Extensions;

public static class EmployeePayslipMapper
{
    public static GetEmployeePayslipDto ToDto(this EmployeePayslip payslip)
    {
        return new GetEmployeePayslipDto
        {
            EmployeeId = payslip.EmployeeId,
            EmployeeName = payslip.EmployeeName,
            SalaryPay = payslip.SalaryPay,
            Benefits = payslip.Benefits,
            PayPeriodStart = payslip.PayPeriodStart,
            PayPeriodEnd = payslip.PayPeriodEnd
        };
    }

    public static EmployeePayslip ToEntity(this GetEmployeePayslipDto dto)
    {
        return new EmployeePayslip
        {
            EmployeeId = dto.EmployeeId,
            EmployeeName = dto.EmployeeName,
            SalaryPay = dto.SalaryPay,
            Benefits = dto.Benefits,
            PayPeriodStart = dto.PayPeriodStart,
            PayPeriodEnd = dto.PayPeriodEnd
        };
    }
}
