using FareManagement.Calculator.Model;

namespace FareManagement.Calculator.MeterOperations
{
    public class FareCalculatorProvider : ICalculatorProvider
    {
        private readonly IFareDetailsBuilder builder;

        public FareCalculatorProvider(IFareDetailsBuilder builder)
        {
            this.builder = builder;
        }

        public FareDetailsBuilder CalculateFare(TripDetail tripDetail)
        {
            return builder//new FareDetails()
                .AddInitialAmount()
                .AddNewyorkTaxSurcharge()
                .CalculateLessThan6MilesPerHourSpeedRangeIndicator(tripDetail.LessThan6MilesPerHourSpeedRangeIndicator)
                .CalculateMoreThan6MilesPerHourOr60SecondsDurationIndicator(tripDetail.MoreThan6MilesPerHourOr60SecondsDurationIndicator)
                .CalculateNightSurcharge(tripDetail.TripDate)
                .CalculatePeakHourWeekDaySurcharge(tripDetail.TripDate)
                .AddInitialAmount();
        }
    }
}
