using DSA.Character.Value;
using DSA.Character.Value.Calculation;

namespace DSA.Character.Modifier
{
    public class MovementCalculation : BaseCalculation<BaseValue>
    {
        private Race race;

        public MovementCalculation(BaseValue targetValue) : base(targetValue)
        {
            race = targetValue.Character.Race;
        }

        protected override int BaseCalculationMethod()
        {
            return race.MovementBase;
        }
    }
}

