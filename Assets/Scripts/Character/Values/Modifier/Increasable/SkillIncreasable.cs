using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public class SkillIncreasable : BaseIncreasable<Skill>
    {
        public override IncreaseCostType IncreaseCostType => targetValue.Data.IncreaseCostType;

        public override int MaxIncreaseValue => base.MaxIncreaseValue + targetValue.BaseAttributes.GetMaxBaseValue() + 2;

        public SkillIncreasable(Skill targetValue) : base(targetValue)
        {
        }
    }
}