using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class PoolValueIncreasable : BaseIncreasable<PoolValue>
    {
        public override IncreaseCostType IncreaseCostType => targetValue.Data.IncreaseCostType;

        public override bool CanBeIncreased => true;

        public PoolValueIncreasable(PoolValue targetValue) : base(targetValue)
        {
        }
    }
}
