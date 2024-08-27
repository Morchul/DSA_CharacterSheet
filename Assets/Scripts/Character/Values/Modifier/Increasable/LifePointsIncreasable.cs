using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class LifePointsIncreasable : BaseIncreasable<PoolValue>
    {
        private MainAttribute constitution;

        public override IncreaseCostType IncreaseCostType => targetValue.Data.IncreaseCostType;

        public override int MaxIncreaseValue => base.MaxIncreaseValue + constitution.Value.BaseValue;

        public LifePointsIncreasable(PoolValue targetValue) : base(targetValue)
        {
            constitution = targetValue.Character.GetAttribute(MainAttributeType.Constitution);
        }
    }
}

