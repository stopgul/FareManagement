using AutoMapper;
using FareManagement.Calculator.MeterOperations;
using FareManagement.Calculator.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FareManagement.Web.Api.Controllers
{
    [Route("api/v1/fair")]
    [ApiController]
    public class FareCalculatorController : ControllerBase
    {
        private readonly ILogger<FareCalculatorController> _log;
        private readonly ICalculatorProvider _fareCalculatorProvider;
        private readonly IMapper _mapper;

        public FareCalculatorController(ILogger<FareCalculatorController> logger, ICalculatorProvider fareCalculatorProvider, IMapper mapper)
        {
            _log = logger;
            _fareCalculatorProvider = fareCalculatorProvider;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Get([FromQuery]TripDetailDto input)
        {
            if (input.LessThan6MilesPerHourSpeedRangeIndicator < 0)
                return BadRequest("LessThan6MilesPerHourSpeedRangeIndicator could not be less than 0!");
            if (input.MoreThan6MilesPerHourOr60SecondsDurationIndicator < 0)
                return BadRequest("MoreThan6MilesPerHourOr60SecondsDurationIndicator could not be less than 0!");
            var tripDetail = _mapper.Map<TripDetail>(input);
            var fareDetails = _fareCalculatorProvider.CalculateFare(tripDetail);
            _log.LogInformation($"Rate: {fareDetails.CalculatedFare}");
            return Ok(fareDetails.CalculatedFare);
        }
        //https://localhost:44308/api/v1/fair?LessThan6MilesPerHourSpeedRangeIndicator=14&CityBasedSurchargeAmount=45.0&TripDate=10-10-2020&MoreThan6MilesPerHourOr60SecondsDurationIndicator=12
    }
}