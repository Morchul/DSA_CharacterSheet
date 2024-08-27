using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class RangedValueCalculation : BaseCalculation<CombatValue>
    {
        private MainAttribute dexterity;

        public RangedValueCalculation(CombatValue targetValue) : base(targetValue)
        {
            dexterity = targetValue.Character.GetAttribute(MainAttributeType.Dexterity);

            dexterity.Value.OnValueChanged += TriggerOnValueChangedEvent;
            targetValue.CombatTechnic.Value.OnValueChanged += TriggerOnValueChangedEvent;
        }

        protected override int BaseCalculationMethod()
        {
            //Full combat technic value plus each 3 full points of dexterity over attr start value (8)
            return targetValue.CombatTechnic.Value.CurrentValue + (dexterity.Value.CurrentValue - Constant.ATTR_START_VALUE) / 3;
        }
    }

    public class RangedValueCalculationFactory : ICombatValueBaseCalculationFactory
    {
        public IBaseModifier Create(CombatValue combatValue)
        {
            return new RangedValueCalculation(combatValue);
        }
    }
}

