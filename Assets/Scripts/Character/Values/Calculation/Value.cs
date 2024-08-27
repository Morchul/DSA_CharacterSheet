using DSA.Character.Modifier;
using System;

namespace DSA.Character.Value.Calculation
{
    public class Value
    {
        protected int baseValue;
        protected int currentValue;

        public int BaseValue => baseValue;
        public int CurrentValue => currentValue;

        private ValueCalculation valueCalculation;
        public ValueCalculationInfo ValueCalculationInfo => valueCalculation.ValueCalculationInfo;

        public event Action OnValueChanged;

        public readonly int Type;

        public Value(int type, IBaseModifier[] baseModifier)
        {
            valueCalculation = new ValueCalculation(baseModifier);
            Type = type;

            for(int i = 0; i < baseModifier.Length; ++i)
            {
                baseModifier[i].OnValueChanged += ModifierChanged;
            }
            RecalculateValue();
        }

        public void AddModifier(IValueModifier modifier)
        {
            Log.Verbose($"Add Modifier to [{Type.GetNameOfValueType()}]");
            valueCalculation.AddModifier(modifier);

            modifier.OnValueChanged += ModifierChanged;
            RecalculateValue();
        }

        public bool RemoveModifier(int type)
        {
            IValueModifier modifier = valueCalculation.RemoveModifier(type);

            if(modifier != null)
            {
                Log.Verbose($"Remove Modifier from [{Type.GetNameOfValueType()}]");
                modifier.OnValueChanged -= ModifierChanged;
                RecalculateValue();
                return true;
            }

            Log.Warning($"Remove Modifier from [{Type.GetNameOfValueType()}] failed!");
            return false;
        }

        public void Recalculate()
        {
            RecalculateValue();
        }

        private void ModifierChanged()
        {
            RecalculateValue();
        }

        protected virtual void RecalculateValue()
        {
            ValueCalculationResult result = valueCalculation.Calculate();

            this.baseValue = result.BaseValue;
            this.currentValue = result.CurrentValue;

            OnValueChanged?.Invoke();
        }
    }
}

