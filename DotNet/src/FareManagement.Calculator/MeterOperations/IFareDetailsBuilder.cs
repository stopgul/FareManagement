using System;

namespace FareManagement.Calculator.MeterOperations
{
    public interface IFareDetailsBuilder
    {
        double CalculatedFare { get; }
        bool InitialAmountAdded { get; }
        bool LessThan6MilesPerHourSpeedRangeIndicatorAdded { get; }
        bool MoreThan6MilesPerHourOr60SecondsDurationIndicatorAdded { get; }
        bool NewyorkStateTacSurchargeAdded { get; }
        bool NightSurchargeAdded { get; }
        bool PeakHourWeekDaySurchargeAdded { get; }

        FareDetailsBuilder AddInitialAmount();
        FareDetailsBuilder AddNewyorkTaxSurcharge();
        FareDetailsBuilder CalculateLessThan6MilesPerHourSpeedRangeIndicator(double lessThan6MilesPerHourSpeedRangeIndicator);
        FareDetailsBuilder CalculateMoreThan6MilesPerHourOr60SecondsDurationIndicator(double moreThan6MilesPerHourOr60SecondsDurationIndicator);
        FareDetailsBuilder CalculateNightSurcharge(DateTime tripDate);
        FareDetailsBuilder CalculatePeakHourWeekDaySurcharge(DateTime tripDate);
    }
}