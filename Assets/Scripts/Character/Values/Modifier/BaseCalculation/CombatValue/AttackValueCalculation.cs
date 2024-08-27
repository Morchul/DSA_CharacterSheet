using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class AttackValueCalculation : BaseCalculation<CombatValue>
    {
        private MainAttribute courage;

        public AttackValueCalculation(CombatValue targetValue) : base(targetValue)
        {
            courage = targetValue.Character.GetAttribute(MainAttributeType.Courage);

            courage.Value.OnValueChanged += TriggerOnValueChangedEvent;
            targetValue.CombatTechnic.Value.OnValueChanged += TriggerOnValueChangedEvent;
        }

        protected override int BaseCalculationMethod()
        {
            //Full combat technic value plus each 3 full points of courage over attr start value (8)
            return targetValue.CombatTechnic.Value.CurrentValue + (courage.Value.CurrentValue - Constant.ATTR_START_VALUE) / 3;
        }
    }

    public class AttackValueCalculationFactory : ICombatValueBaseCalculationFactory
    {
        public IBaseModifier Create(CombatValue combatValue)
        {
            return new AttackValueCalculation(combatValue);
        }
    }
}

