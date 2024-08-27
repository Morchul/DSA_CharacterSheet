using DSA.Character.Value;
using DSA.Character.Value.Calculation;

namespace DSA.Character.Modifier
{
    public class KarmaPointsCalculation : BaseCalculation<PoolValue>
    {
        public KarmaPointsCalculation(PoolValue targetValue) : base(targetValue)
        {
        }

        protected override int BaseCalculationMethod()
        {
            throw new System.NotImplementedException();
        }
    }
}

