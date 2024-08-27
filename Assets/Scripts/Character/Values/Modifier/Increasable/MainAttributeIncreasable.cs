using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class MainAttributeIncreasable : BaseIncreasable<MainAttribute>
    {
        public override IncreaseCostType IncreaseCostType => targetValue.Data.IncreaseCostType;

        public override int MinIncreaseValue => Constant.ATTR_START_VALUE;

        public override bool CanBeIncreased => true;

        protected override int DefaultValue => Constant.ATTR_START_VALUE;

        public MainAttributeIncreasable(MainAttribute targetValue) : base(targetValue)
        {
        }
    }
}

