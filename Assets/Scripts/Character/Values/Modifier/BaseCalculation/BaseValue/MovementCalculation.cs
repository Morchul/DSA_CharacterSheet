using DSA.Character.Value;

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

    public class MovementCalculationFactory : IBaseValueBaseCalculationFactory
    {
        public IBaseModifier Create(BaseValue baseValue)
        {
            return new MovementCalculation(baseValue);
        }
    }
}

