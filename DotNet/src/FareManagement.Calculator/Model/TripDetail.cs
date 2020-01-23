using System;
using System.ComponentModel.DataAnnotations;

namespace FareManagement.Calculator.Model
{
    public class TripDetail
    {
        [Required]
        public DateTime TripDate { get; set; }
        [Required]
        public int MoreThan6MilesPerHourOr60SecondsDurationIndicator { get; set; }
        [Required]
        public int LessThan6MilesPerHourSpeedRangeIndicator { get; set; }
        //[Required]
        public double CityBasedSurchargeAmount { get; set; }
    }
}
