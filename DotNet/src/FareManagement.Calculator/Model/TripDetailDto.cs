using System;
using System.ComponentModel.DataAnnotations;

namespace FareManagement.Calculator.Model
{
    public class TripDetailDto
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime? TripDate { get; set; }
        [Required]
        [Range(0, 999)]
        public int? MoreThan6MilesPerHourOr60SecondsDurationIndicator { get; set; }
        [Required]
        [Range(0, 999)]
        public int? LessThan6MilesPerHourSpeedRangeIndicator { get; set; }
        //[Required]
        [Range(0, 99.99)]
        public double? CityBasedSurchargeAmount { get; set; }
    }
}
