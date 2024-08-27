using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class InitiativeCalculation : BaseCalculation<BaseValue>
    {
        private MainAttribute courage;
        private MainAttribute agility;

        public InitiativeCalculation(BaseValue targetValue) : base(targetValue)
        {
            courage = targetValue.Character.GetAttribute(MainAttributeType.Courage);
            agility = targetValue.Character.GetAttribute(MainAttributeType.Agility);

            courage.Value.OnValueChanged += TriggerOnValueChangedEvent;
            agility.Value.OnValueChanged += TriggerOnValueChangedEvent;
        }

        protected override int BaseCalculationMethod()
        {
            return MathUtility.DivideByTwo(courage.Value.CurrentValue + agility.Value.CurrentValue);
        }
    }

    public class InitiativeCalculationFactory : IBaseValueBaseCalculationFactory
    {
        public IBaseModifier Create(BaseValue baseValue)
        {
            return new InitiativeCalculation(baseValue);
        }
    }
}

