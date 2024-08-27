using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class ToughnessCalculation : BaseCalculation<BaseValue>
    {
        private Race race;
        private MainAttribute constitution;
        private MainAttribute strength;

        public ToughnessCalculation(BaseValue targetValue) : base(targetValue)
        {
            race = targetValue.Character.Race;
            constitution = targetValue.Character.GetAttribute(MainAttributeType.Constitution);
            strength = targetValue.Character.GetAttribute(MainAttributeType.Strength);

            constitution.Value.OnValueChanged += TriggerOnValueChangedEvent;
            strength.Value.OnValueChanged += TriggerOnValueChangedEvent;
        }

        protected override int BaseCalculationMethod()
        {
            return race.ToughnessBase + MathUtility.DivideBySix(2 * constitution.Value.CurrentValue + strength.Value.CurrentValue);
        }
    }

    public class ToughnessCalculationFactory : IBaseValueBaseCalculationFactory
    {
        public IBaseModifier Create(BaseValue baseValue)
        {
            return new ToughnessCalculation(baseValue);
        }
    }
}

