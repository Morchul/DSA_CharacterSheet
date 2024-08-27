using DSA.Character.Test;
using UnityEngine.Localization;

namespace DSA.Character.Effect
{
    public interface IEffect
    {
        public LocalizedString Name { get; }
        public LocalizedString Description { get; }
        public int Type { get; }

        public TestCalculationStage Stage { get; }

        public TestCalculationMethod CalculationMethod { get; }

        public event System.Action OnModifikationChanged;
    }
}