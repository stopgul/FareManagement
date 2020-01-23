using FareManagement.Calculator.Model;

namespace FareManagement.Calculator.MeterOperations
{
    public interface ICalculatorProvider
    {
        FareDetails CalculateFare(TripDetail tripDetail);
    }
}
