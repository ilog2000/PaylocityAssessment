using System;

namespace Api.Extensions;

public static class CalculationExtensions
{
    public static decimal AnnualToPaycheck(decimal amount, int paychecksPerYear)
    {
        return Math.Round(amount / paychecksPerYear, 2); // Convert annual amount to payment period and round to cents
    }

    public static decimal MonthlyToPaycheck(decimal amount, int paychecksPerYear)
    {
        return Math.Round(amount * 12 / paychecksPerYear, 2); // Convert monthly amount to payment period and round to cents
    }
}
