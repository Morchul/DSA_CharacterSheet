using DSA.Character.Value.Calculation;
using UnityEngine.Localization;

namespace DSA.Character.Modifier
{
    public interface IModifier
    {
        public LocalizedString Name { get; }
        public LocalizedString Description { get; }
        public int Type { get; }

        public event System.Action OnValueChanged;
    }

    public interface IValueModifier : IModifier
    {
        public CalculationMethod CalculationMethod { get; }
    }

    public interface IBaseModifier : IModifier
    {
        public BaseCalculationMethod CalculationMethod { get; }
    }
}