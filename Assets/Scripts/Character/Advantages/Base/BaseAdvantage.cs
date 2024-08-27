using UnityEngine;

namespace DSA.Character.Advantage
{
    public abstract class BaseAdvantage : ScriptableObject
    {
        [SerializeField]
        private AdvantageType type;

        public AdvantageType Type => type;
    }
}
