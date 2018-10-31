
namespace BankAccount
{
    public interface IPointsCalculations
    {
        int Calculations(int weight);
    }

    public class PlusCalculator : IPointsCalculations
    {
        public int Calculations(int weight)
        {
            return weight;
        }
    }

    public class MultCalculator : IPointsCalculations
    {
        public int Calculations(int weight)
        {
            return 2 * weight / 5;
        }
    }
}