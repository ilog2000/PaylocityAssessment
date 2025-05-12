using System;

namespace Api.Models;

public class EmployeePayslip
{
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; } // IMPORTANT: The Employee property should always be populated (with a deep copy)
    public string EmployeeName { get; set; } = string.Empty; // Last name then first name
    public decimal SalaryPay { get; set; } // Part of the salary for the pay period
    public decimal Benefits { get; set; } // Benefits adjusted for the pay period
    public DateTime PayPeriodStart { get; set; }
    public DateTime PayPeriodEnd { get; set; }
}
