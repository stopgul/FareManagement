using FareManagement.Calculator.MeterOperations;
using FareManagement.Calculator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FareManagement.Calculator.Test
{
    [TestClass]
    public class FareCalculatorProviderTests
    {
        private readonly TripDetail tripDetail;
        private readonly FareCalculatorProvider subject;

        public FareCalculatorProviderTests()
        {
            tripDetail = new TripDetail()
            {
                CityBasedSurchargeAmount = 0.5,
                LessThan6MilesPerHourSpeedRangeIndicator = 2,
                MoreThan6MilesPerHourOr60SecondsDurationIndicator = 5,
                TripDate = Convert.ToDateTime("01/17/2020 5:30pm")
            };
            subject = new FareCalculatorProvider(new FareDetailsBuilder());
        }

        [TestMethod]
        public void CalculateFare_ShouldReturnCorrectAmount_When_Called()
        {
            double expectedResult = 9.75;
            double actualResult = subject.CalculateFare(tripDetail).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
