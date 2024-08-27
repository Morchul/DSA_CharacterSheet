using DSA.Character.Value.Calculation;

namespace DSA.Character.Value
{
    public abstract class CharacterValueBase
    {
        public Character Character { get; }
        public Calculation.Value Value { get; protected set; }

        public abstract int Type { get; }
        public abstract string Name { get; }

        public CharacterValueBase(Character character)
        {
            this.Character = character;
        }

        protected void AttachLogCalculation()
        {
            if (Log.IsLogLevelActive(Log.LogLevel.Calculation))
            {
                Value.OnValueChanged += LogCalculation;
            }
        }

        private void LogCalculation()
        {
            Log.Calculation($"Calculation of Value [{Type.GetNameOfValueType()}]:");
            foreach (ModifierInfo calculationStepInfo in Value.ValueCalculationInfo)
            {
                Log.Calculation(calculationStepInfo.Name.GetLocalizedString() + "/" + calculationStepInfo.ValueChange);
            }
            Log.Calculation($"Final Values of [{Type.GetNameOfValueType()}] = Base: {Value.BaseValue} / Current: {Value.CurrentValue}");
        }
    }
}
