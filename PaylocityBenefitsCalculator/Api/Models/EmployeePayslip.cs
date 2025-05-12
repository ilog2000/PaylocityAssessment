using System;

namespace Api.Models;

public class EmployeePayslip
{
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public decimal SalaryPay { get; set; }
    public decimal Benefits { get; set; }
    public DateTime PayPeriodStart { get; set; }
    public DateTime PayPeriodEnd { get; set; }
}
