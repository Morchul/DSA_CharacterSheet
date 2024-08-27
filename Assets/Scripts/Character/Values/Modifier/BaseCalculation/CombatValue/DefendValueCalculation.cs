using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class DefendValueCalculation : BaseCalculation<CombatValue>
    {
        public DefendValueCalculation(CombatValue targetValue) : base(targetValue)
        {
            targetValue.CombatTechnic.Value.OnValueChanged += TriggerOnValueChangedEvent;

            for (int i = 0; i < targetValue.CombatTechnic.PrimaryAttributes.Length; ++i)
            {
                targetValue.CombatTechnic.PrimaryAttributes[i].Value.OnValueChanged += TriggerOnValueChangedEvent;
            }
        }

        protected override int BaseCalculationMethod()
        {
            //Half combat technic value plus each 3 full points over attr start value (8) in primary attribute
            return MathUtility.DivideByTwo(targetValue.CombatTechnic.Value.CurrentValue) + (targetValue.CombatTechnic.PrimaryAttributes.GetMaxBaseValue() - Constant.ATTR_START_VALUE) / 3;
        }
    }

    public class DefendValueCalculationFactory : ICombatValueBaseCalculationFactory
    {
        public IBaseModifier Create(CombatValue combatValue)
        {
            return new DefendValueCalculation(combatValue);
        }
    }
}
