namespace DSA.Character.Modifier
{
    public interface IIncreasable : IBaseModifier
    {
        public IncreaseCostType IncreaseCostType { get; }

        public bool CanBeIncreased { get; }
        public bool CanBeDecreased { get; }

        public int IncreaseValue { get; set; }

        public void AddIncreasableMaxModifier(IncreasableMaxModifier modifier);
        public IncreasableMaxModifier RemoveIncreasableMaxModifier(int type);

        public void Change(int change);
    }

    public class IncreasableMaxModifier
    {
        public int Type { get; }

        public int Modification { get; }

        public string Description { get; }

        public IncreasableMaxModifier(int type, int modification, string description)
        {
            Type = type;
            Modification = modification;
            Description = description;
        }
    }
}

