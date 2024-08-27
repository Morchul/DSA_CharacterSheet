using DSA.Character.Value;
using UnityEngine;

namespace DSA.Character.Modifier
{
    public class CombatTechnicIncreasable : BaseIncreasable<CombatTechnic>
    {
        public override IncreaseCostType IncreaseCostType => targetValue.Data.IncreaseCostType;

        public override int MaxIncreaseValue => base.MaxIncreaseValue + GetMaxIncreasable();
        public override int MinIncreaseValue => Constant.COMBAT_TECHNIC_START_VALUE;

        protected override int DefaultValue => Constant.COMBAT_TECHNIC_START_VALUE;

        public CombatTechnicIncreasable(CombatTechnic targetValue) : base(targetValue)
        {
        }

        private int GetMaxIncreasable()
        {
            int max = 0;
            for (int i = 0; i < targetValue.PrimaryAttributes.Length; ++i)
            {
                max = Mathf.Max(max, targetValue.PrimaryAttributes[i].Value.BaseValue);
            }

            return max + 2;
        }
    }
}

