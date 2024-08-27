using DSA.Character.Value;
using DSA.Character.Value.Calculation;
using System;
using UnityEngine;
using UnityEngine.Localization;

namespace DSA.Character.Modifier
{
    public abstract class BaseCalculation<T> : IBaseModifier where T : CharacterValueBase
    {
        [SerializeField]
        private LocalizedString localizedName;

        [SerializeField]
        private LocalizedString localizedDescription;

        public BaseCalculationMethod CalculationMethod => BaseCalculationMethod;
        public LocalizedString Name => localizedName;
        public LocalizedString Description => localizedDescription;

        public int Type => targetValue.Type;

        public event Action OnValueChanged;

        protected T targetValue;

        public BaseCalculation(T targetValue)
        {
            this.targetValue = targetValue;
        }

        protected void TriggerOnValueChangedEvent()
        {
            OnValueChanged?.Invoke();
        }

        protected abstract int BaseCalculationMethod();
    }
}

