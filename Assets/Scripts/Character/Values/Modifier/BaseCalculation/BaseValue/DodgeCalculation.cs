using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class DodgeCalculation : BaseCalculation<BaseValue>
    {
        private MainAttribute agility;

        public DodgeCalculation(BaseValue targetValue) : base(targetValue)
        {
            agility = targetValue.Character.GetAttribute(MainAttributeType.Agility);

            agility.Value.OnValueChanged += TriggerOnValueChangedEvent;
        }

        protected override int BaseCalculationMethod()
        {
            return MathUtility.DivideByTwo(agility.Value.CurrentValue);
        }
    }
}

