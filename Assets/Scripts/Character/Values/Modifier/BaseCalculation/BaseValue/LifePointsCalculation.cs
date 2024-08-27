using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class LifePointsCalculation : BaseCalculation<PoolValue>
    {
        private MainAttribute constitution;
        private Race race;

        public LifePointsCalculation(PoolValue targetValue) : base(targetValue)
        {
            constitution = targetValue.Character.GetAttribute(MainAttributeType.Constitution);
            race = targetValue.Character.Race;

            constitution.Value.OnValueChanged += TriggerOnValueChangedEvent;
        }

        protected override int BaseCalculationMethod()
        {
            return race.LifePointBase + 2 * constitution.Value.CurrentValue;
        }
    }
}

