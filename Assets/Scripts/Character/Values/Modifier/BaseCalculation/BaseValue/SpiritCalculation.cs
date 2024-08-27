using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class SpiritCalculation : BaseCalculation<BaseValue>
    {
        private Race race;
        private MainAttribute courage;
        private MainAttribute sagacity;
        private MainAttribute intuition;

        public SpiritCalculation(BaseValue targetValue) : base(targetValue)
        {
            race = targetValue.Character.Race;
            courage = targetValue.Character.GetAttribute(MainAttributeType.Courage);
            sagacity = targetValue.Character.GetAttribute(MainAttributeType.Sagacity);
            intuition = targetValue.Character.GetAttribute(MainAttributeType.Intuition);

            courage.Value.OnValueChanged += TriggerOnValueChangedEvent;
            sagacity.Value.OnValueChanged += TriggerOnValueChangedEvent;
            intuition.Value.OnValueChanged += TriggerOnValueChangedEvent;
        }

        protected override int BaseCalculationMethod()
        {
            return race.SpiritBase + MathUtility.DivideBySix(courage.Value.CurrentValue + sagacity.Value.CurrentValue + intuition.Value.CurrentValue);
        }
    }

    public class SpiritCalculationFactory : IBaseValueBaseCalculationFactory
    {
        public IBaseModifier Create(BaseValue baseValue)
        {
            return new SpiritCalculation(baseValue);
        }
    }
}

