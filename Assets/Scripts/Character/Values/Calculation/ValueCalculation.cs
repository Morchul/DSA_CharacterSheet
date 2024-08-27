using DSA.Character.Modifier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;

namespace DSA.Character.Value.Calculation
{
    public class ValueCalculation
    {
        private List<IValueModifier> modifiers;
        private IBaseModifier[] baseModifiers;

        public readonly ValueCalculationInfo ValueCalculationInfo;

        public ValueCalculation(IBaseModifier[] baseModifiers)
        {
            ValueCalculationInfo = new ValueCalculationInfo();

            this.baseModifiers = baseModifiers;
            modifiers = new List<IValueModifier>();

            Calculate();
        }

        public void AddModifier(IValueModifier modifier)
        {
            modifiers.Add(modifier);
        }

        public IValueModifier RemoveModifier(int type)
        {
            for(int i = 0; i < modifiers.Count; ++i)
            {
                IValueModifier modifier = modifiers[i];
                if (modifier.Type == type)
                {
                    modifiers.RemoveAt(i);
                    return modifier;
                }
            }
            return null;
        }

        public ValueCalculationResult Calculate()
        {
            ValueCalculationInfo.Clear();
            
            ValueCalculationResult result = new ValueCalculationResult();

            foreach (IBaseModifier baseModifier in baseModifiers)
            {
                int calculationResult = baseModifier.CalculationMethod();
                ValueCalculationInfo.Add(baseModifier, calculationResult);
                result.BaseValue += calculationResult;
            }

            result.CurrentValue = result.BaseValue;

            ValueCalculationParams calculationParam = new ValueCalculationParams(result.BaseValue);

            foreach (IValueModifier modifier in modifiers)
            {
                int calculationResult = modifier.CalculationMethod(calculationParam);
                ValueCalculationInfo.Add(modifier, calculationResult);
                result.CurrentValue += calculationResult;
            }

            return result;
        }
    }

    public class ValueCalculationInfo : IEnumerable<ModifierInfo>
    {
        private readonly List<ModifierInfo> calculationStepInfos;

        public ValueCalculationInfo()
        {
            calculationStepInfos = new List<ModifierInfo>();
        }

        internal void Clear()
        {
            calculationStepInfos.Clear();
        }

        internal void Add(IModifier modifier, int stepResult)
        {
            calculationStepInfos.Add(new ModifierInfo(modifier.Name, modifier.Description, stepResult));
        }

        public IEnumerator<ModifierInfo> GetEnumerator() => calculationStepInfos.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => calculationStepInfos.GetEnumerator();
    }

    public class ModifierInfo
    {
        public readonly LocalizedString Name;
        public readonly LocalizedString Description;
        public readonly int ValueChange;

        public ModifierInfo(LocalizedString name, LocalizedString description, int valueChange)
        {
            this.Name = name;
            this.Description = description;
            this.ValueChange = valueChange;
        }
    }
}

