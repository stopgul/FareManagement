using FareManagement.Calculator.Model;

namespace FareManagement.Calculator.MeterOperations
{
    public interface ICalculatorProvider
    {
        FareDetailsBuilder CalculateFare(TripDetail tripDetail);
    }
}
