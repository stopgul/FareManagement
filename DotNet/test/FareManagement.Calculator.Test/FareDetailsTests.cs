using FareManagement.Calculator.MeterOperations;
using FareManagement.Calculator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FareManagement.Calculator
{
    [TestClass]
    public class FareDetailsTests
    {
        readonly TripDetail tripDetail;
        readonly FareDetailsBuilder subject;

        public FareDetailsTests()
        {
            tripDetail = new TripDetail()
            {
                CityBasedSurchargeAmount = 0.5,
                LessThan6MilesPerHourSpeedRangeIndicator = 2,
                MoreThan6MilesPerHourOr60SecondsDurationIndicator = 5,
                TripDate = Convert.ToDateTime("01/17/2020 5:30pm")
            };
            subject = new FareDetailsBuilder();
        }

        [TestMethod]
        public void CalculateNightSurcharge_ShouldReturn05_When_Night()
        {
            tripDetail.TripDate = Convert.ToDateTime("01/17/2020 9:30pm");
            double expectedResult = 0.5;
            double actualResult = subject.CalculateNightSurcharge(tripDetail.TripDate).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculateNightSurcharge_ShouldReturn0_When_NotNight()
        {
            tripDetail.TripDate = Convert.ToDateTime("01/17/2020 5:30pm");
            double expectedResult = 0;
            double actualResult = subject.CalculateNightSurcharge(tripDetail.TripDate).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculatePeakHourWeekDaySurcharge_ShouldReturn1_When_PeakHours()
        {
            tripDetail.TripDate = Convert.ToDateTime("01/17/2020 5:30pm");
            double expectedResult = 1;
            double actualResult = subject.CalculatePeakHourWeekDaySurcharge(tripDetail.TripDate).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculatePeakHourWeekDaySurcharge_ShouldReturn0_When_Weekend()
        {
            tripDetail.TripDate = Convert.ToDateTime("01/18/2020 5:30pm");
            double expectedResult = 0;
            double actualResult = subject.CalculatePeakHourWeekDaySurcharge(tripDetail.TripDate).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculatePeakHourWeekDaySurcharge_ShouldReturn0_When_NotWeekendAndOutOfHours()
        {
            tripDetail.TripDate = Convert.ToDateTime("01/17/2020 3:30pm");
            double expectedResult = 0;
            double actualResult = subject.CalculatePeakHourWeekDaySurcharge(tripDetail.TripDate).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddInitialAmount_ShouldReturnInitialAmount_When_Called()
        {
            double expectedResult = 3;
            double actualResult = subject.AddInitialAmount().CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddNewyorkTaxSurcharge_ShouldReturnTaxPrice_When_Called()
        {
            double expectedResult = 0.5;
            double actualResult = subject.AddNewyorkTaxSurcharge().CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculateLessThan6MilesPerHourSpeedRangeIndicator_ShouldReturnCorrectAmount_When_IndicatorHasValue()
        {
            tripDetail.LessThan6MilesPerHourSpeedRangeIndicator = 2;
            double expectedResult = 3.5;
            double actualResult = subject.CalculateLessThan6MilesPerHourSpeedRangeIndicator(tripDetail.LessThan6MilesPerHourSpeedRangeIndicator).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculateLessThan6MilesPerHourSpeedRangeIndicator_ShouldReturnCorrectAmount_When_IndicatorHasNoValue()
        {
            tripDetail.LessThan6MilesPerHourSpeedRangeIndicator = 0;
            double expectedResult = 0;
            double actualResult = subject.CalculateLessThan6MilesPerHourSpeedRangeIndicator(tripDetail.LessThan6MilesPerHourSpeedRangeIndicator).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculateMoreThan6MilesPerHourOr60SecondsDurationIndicator_ShouldReturnCorrectAmount_When_IndicatorHasValue()
        {
            tripDetail.MoreThan6MilesPerHourOr60SecondsDurationIndicator = 5;
            double expectedResult = 1.75;
            double actualResult = subject.CalculateMoreThan6MilesPerHourOr60SecondsDurationIndicator(tripDetail.MoreThan6MilesPerHourOr60SecondsDurationIndicator).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculateMoreThan6MilesPerHourOr60SecondsDurationIndicator_ShouldReturnCorrectAmount_When_IndicatorHasNoValue()
        {
            tripDetail.MoreThan6MilesPerHourOr60SecondsDurationIndicator = 0;
            double expectedResult = 0;
            double actualResult = subject.CalculateMoreThan6MilesPerHourOr60SecondsDurationIndicator(tripDetail.MoreThan6MilesPerHourOr60SecondsDurationIndicator).CalculatedFare;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
