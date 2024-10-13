using DSA.Character.Value;
using DSA.Character.Value.Calculation;
using System;
using System.Collections.Generic;
using UnityEngine.Localization;

namespace DSA.Character.Modifier
{
    public abstract class BaseIncreasable<T> : IIncreasable where T : CharacterValueBase
    {
        protected T targetValue;

        protected int increaseValue;

        public abstract IncreaseCostType IncreaseCostType { get; }

        public virtual int MaxIncreaseValue => 0; //TODO add maxmodifiers
        public virtual int MinIncreaseValue => 0;

        public virtual bool CanBeIncreased => increaseValue < MaxIncreaseValue;
        public virtual bool CanBeDecreased => increaseValue > MinIncreaseValue;

        protected int maxModifier;
        protected string maxModifierDescription;

        public int Type => targetValue.Type;

        protected virtual int DefaultValue => 0;

        protected List<IncreasableMaxModifier> maxModifiers;

        public int IncreaseValue
        {
            get => increaseValue;
            set
            {
                increaseValue = value;
                TriggerOnValueChangedEvent();
            }
        }

        public LocalizedString Name { get; private set; }
        public LocalizedString Description { get; private set; }

        public BaseCalculationMethod CalculationMethod => IncreaseCalculateStep;

        public event Action OnValueChanged;

        public BaseIncreasable(T targetValue)
        {
            this.targetValue = targetValue;
            //Name = Localization.Instance.GetLocalizedString(LocalizationKeys.INCREASABLE_NAME);
            //Description = Localization.Instance.GetLocalizedString(LocalizationKeys.INCREASABLE_DESCRIPTION);

            maxModifiers = new List<IncreasableMaxModifier>();

            Log.Verbose($"Init [{Type.GetNameOfValueType()}] Increasable with {DefaultValue}");
            Change(DefaultValue);
        }

        public virtual void Change(int change)
        {
            increaseValue += change;
            TriggerOnValueChangedEvent();
        }

        protected void TriggerOnValueChangedEvent()
        {
            OnValueChanged?.Invoke();
        }

        protected virtual int IncreaseCalculateStep()
        {
            return increaseValue;
        }

        public void AddIncreasableMaxModifier(IncreasableMaxModifier modifier)
        {
            maxModifiers.Add(modifier);
            UpdateMaxModifier();
        }

        public IncreasableMaxModifier RemoveIncreasableMaxModifier(int type)
        {
            for(int i = 0; i < maxModifiers.Count; ++i)
            {
                IncreasableMaxModifier modifier = maxModifiers[i];
                if(modifier.Type == type)
                {
                    maxModifiers.RemoveAt(i);
                    UpdateMaxModifier();
                    return modifier;
                }
            }

            return null;
        }

        private void UpdateMaxModifier()
        {
            maxModifier = 0;
            maxModifierDescription = "";


            foreach (IncreasableMaxModifier modifier in maxModifiers)
            {
                maxModifier += modifier.Modification;
                maxModifierDescription += " " + modifier.Description;
            }
        }
    }
}
