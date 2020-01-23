using FareManagement.Calculator.Model;
using System;

namespace FareManagement.Calculator.MeterOperations
{
    public class FareDetails
    {
        public const double AdditionalUnitIndicator = 0.35;

        public double CalculatedFare { get; private set; }
        public bool InitialAmountAdded { get; private set; }
        public bool LessThan6MilesPerHourSpeedRangeIndicatorAdded { get; private set; }
        public bool MoreThan6MilesPerHourOr60SecondsDurationIndicatorAdded { get; private set; }
        public bool NightSurchargeAdded { get; private set; }
        public bool PeakHourWeekDaySurchargeAdded { get; private set; }
        public bool NewyorkStateTacSurchargeAdded { get; private set; }

        public FareDetails AddInitialAmount()
        {
            CalculatedFare += 3;
            InitialAmountAdded = true;
            return this;
        }

        public FareDetails AddNewyorkTaxSurcharge()
        {
            CalculatedFare += 0.5;
            NewyorkStateTacSurchargeAdded = true;
            return this;
        }

        public FareDetails CalculateLessThan6MilesPerHourSpeedRangeIndicator(double lessThan6MilesPerHourSpeedRangeIndicator)
        {
            double calculation = (lessThan6MilesPerHourSpeedRangeIndicator / (0.20)) * AdditionalUnitIndicator;

            if (calculation > 0)
            {
                CalculatedFare += calculation;
                LessThan6MilesPerHourSpeedRangeIndicatorAdded = true;
            }
            return this;
        }

        public FareDetails CalculateMoreThan6MilesPerHourOr60SecondsDurationIndicator(double moreThan6MilesPerHourOr60SecondsDurationIndicator)
        {
            double calculation = moreThan6MilesPerHourOr60SecondsDurationIndicator * AdditionalUnitIndicator;
            if (calculation > 0)
            {
                CalculatedFare += calculation;
                MoreThan6MilesPerHourOr60SecondsDurationIndicatorAdded = true;
            }
            return this;
        }

        public FareDetails CalculateNightSurcharge(DateTime tripDate)
        {
            if (tripDate.Hour > 20 || tripDate.Hour < 6)
            {
                CalculatedFare += 0.5;
                NightSurchargeAdded = true;
            }
            return this;
        }

        public FareDetails CalculatePeakHourWeekDaySurcharge(DateTime tripDate)
        {
            if (tripDate.DayOfWeek == DayOfWeek.Sunday || tripDate.DayOfWeek == DayOfWeek.Saturday)
                return this;
            if (tripDate.Hour > 16 && tripDate.Hour < 20)
            {
                CalculatedFare += 1;
                PeakHourWeekDaySurchargeAdded = true;
            }
            return this;
        }
    }
}
