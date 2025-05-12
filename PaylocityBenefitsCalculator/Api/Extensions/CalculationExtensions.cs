using System;

namespace Api.Extensions;

public static class CalculationExtensions
{
    public static decimal FromAnnualToPaycheck(this decimal amount)
    {
        return Math.Round(amount / Constants.PaychecksPerYear, 2); // Re-calculate annual amount to payment period and round to cents
    }

    public static decimal FromMonthlyToPaycheck(this decimal amount)
    {
        return Math.Round(amount * 12 / Constants.PaychecksPerYear, 2); // Re-calculate monthly amount to payment period and round to cents
    }
}
