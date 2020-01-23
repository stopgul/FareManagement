using FareManagement.Calculator.Model;

namespace FareManagement.Calculator.MeterOperations
{
    public class FareCalculatorProvider : ICalculatorProvider
    {
        public FareDetails CalculateFare(TripDetail tripDetail)
        {
            return new FareDetails()
                .AddInitialAmount()
                .AddNewyorkTaxSurcharge()
                .CalculateLessThan6MilesPerHourSpeedRangeIndicator(tripDetail.LessThan6MilesPerHourSpeedRangeIndicator)
                .CalculateMoreThan6MilesPerHourOr60SecondsDurationIndicator(tripDetail.MoreThan6MilesPerHourOr60SecondsDurationIndicator)
                .CalculateNightSurcharge(tripDetail.TripDate)
                .CalculatePeakHourWeekDaySurcharge(tripDetail.TripDate);
        }
    }
}
